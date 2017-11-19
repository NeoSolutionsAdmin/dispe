import java.io.File;
import java.io.IOException;
import java.net.URI;
import java.nio.charset.Charset;
import java.nio.file.FileSystem;
import java.nio.file.Files;
import java.nio.file.LinkOption;
import java.nio.file.OpenOption;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.nio.file.WatchKey;
import java.nio.file.WatchService;
import java.nio.file.WatchEvent.Kind;
import java.nio.file.WatchEvent.Modifier;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import javax.tools.JavaCompiler;

import com.pengrad.telegrambot.TelegramBot;
import com.pengrad.telegrambot.UpdatesListener;
import com.pengrad.telegrambot.model.Audio;
import com.pengrad.telegrambot.model.CallbackQuery;
import com.pengrad.telegrambot.model.Message;
import com.pengrad.telegrambot.model.Update;
import com.pengrad.telegrambot.model.User;
import com.pengrad.telegrambot.model.request.ParseMode;
import com.pengrad.telegrambot.request.AnswerCallbackQuery;
import com.pengrad.telegrambot.request.ForwardMessage;
import com.pengrad.telegrambot.request.GetUpdates;
import com.pengrad.telegrambot.request.SendChatAction;
import com.pengrad.telegrambot.request.SendMessage;
import com.pengrad.telegrambot.request.SetWebhook;

public class Init {

	
	public static TelegramBot TB;
	public static boolean next=true;
	public static String PathWallet; 
	
	public static void showhelp(long chatid)
	{
		SendMessage SM = new SendMessage(chatid, 
				
		"Ayuda de *TRANSPONDO*:\n" + 
		 
		"*.help* : Muestra Ayuda\n" +
		
		"*.wallet* : Crear|Consultar wallet \n" +
		
		"*.index* : Indice de wallets registradas \n" +
		
		"*.transfer [idwallet] [amount]* : Realiza transferencia \n" +
		
		"*.ping* : Chequea el nivel de pong \n" 
						);
		SM.parseMode(ParseMode.Markdown);
		TB.execute(SM);
		
		
		
	}
	
	
	
	public static void setFiles()
	{
		try {
			String currentDirectory = new File(".").getCanonicalPath();
			System.out.println(currentDirectory);
			
			String pathbalance;
			if (System.getProperty("os.name").toLowerCase().contains("windows")==true)
			{
				pathbalance=".\\beolp.db";
				

			} else 
			{
				pathbalance="./beolp.db";
			}
			PathWallet = pathbalance;
			if (new File(pathbalance).exists()==false)
			{
				File F = new File(pathbalance);
				F.createNewFile();
				Files.write(Paths.get(pathbalance),"registro de beolps\n".getBytes(),StandardOpenOption.APPEND);
			} 
			
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} 
	}
	
	public static int checkwalletexists(int IdUser, User USR)
	{
		List<String> Wallets = null;
		Path P = Paths.get(PathWallet);
		try {
			Wallets = Files.readAllLines(P);
			if (Wallets!=null && Wallets.size()>0)
			{
				
				for (int a=0;a<Wallets.size();a++)
				{
					if (Wallets.get(a).split("%").length>1)
					{
						String[] Fields = Wallets.get(a).split("%");
						if (Fields[0].equals(String.valueOf(IdUser)))
						{
							return IdUser;
						} 
					}
					
						
					
				}
				String record = String.valueOf(IdUser) + "%" + Wallets.size() + "%" + USR.firstName() + "%" + "20\n";
				Files.write(Paths.get(PathWallet),record.getBytes(),StandardOpenOption.APPEND);
				return IdUser;
			}
			return 0;
			
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			return -1;
		}
		
	}
	
	
	
	public static void createwallet(int userid, long chatid, User USR)
	{
		int user = checkwalletexists(userid,USR);
		if (user!=0 && user!=-1)
		{
			Path P = Paths.get(PathWallet);
			List<String> Wallets=null;
			try{
			 Wallets =  Files.readAllLines(P);
			} catch (Exception E)
			{
				
			}
			boolean foundit = false;
			float Saldo=0;
			if (Wallets!=null)
			{
				for (int a=0;a<Wallets.size();a++)
				{
					String[] W = Wallets.get(a).split("%");
					if (W.length>1)
					{
						if (W[0].equals(String.valueOf(userid)))
						{
							foundit=true;
							Saldo = Float.valueOf(W[3]);
							break;
						}
					}
				}
			}
			
			SendMessage SM = new SendMessage(chatid, "@" + USR.firstName() + "\n" + "Saldo:*"  + String.valueOf(Saldo) + "*");
			SM.parseMode(ParseMode.Markdown);
			
					SM.parseMode(ParseMode.Markdown);
					TB.execute(SM);
		}
	}
	
	public static void index(long idchat, User USR)
	{
		Path P = Paths.get(PathWallet);
		List<String> Wallets=null;
		try{
		 Wallets =  Files.readAllLines(P);
		} catch (Exception E)
		{
			
		}
		if (Wallets!=null && Wallets.size()>1)
		{
			String MSG = "*Listado de Wallets:*\n";
			for (int a=1;a<Wallets.size();a++)
			{
				String[] FLDS = Wallets.get(a).split("%");
				if (Integer.valueOf(FLDS[0]).equals(USR.id())==false)
				{
					MSG=MSG+"- ";
				} else 
				{
					MSG=MSG+"*+ *";
				}
				MSG=MSG + "*" + FLDS[2] + "*: " + FLDS[1] + "\n";
				
				
				
			} 
			SendMessage SM = new SendMessage(idchat, MSG);
			SM.parseMode(ParseMode.Markdown);
			TB.execute(SM);
			
		} 
	}
	
	public static boolean transfer(long idchat, User USR, Message text)
	{
		String txt = text.text().toLowerCase();
		Integer indexsender=0;
		Integer indexreceiver=0;
		String parametros[] = txt.split(" ");
		
		if (parametros.length!=3)
		{
			SendMessage SM = new SendMessage(idchat, "Error en transferencia...");
			SM.parseMode(ParseMode.Markdown);
			TB.execute(SM);
			return false;
			
		}
		
		
		
		Path P = Paths.get(PathWallet);
		List<String> Wallets=null;
		try{
		 Wallets =  Files.readAllLines(P);
		} catch (Exception E)
		{
			return false;
		}
		if (Wallets!=null && Wallets.size()>1)
		{
			
			for (int a=1;a<Wallets.size();a++)
			{
				String[] FLDS = Wallets.get(a).split("%");
				if (Integer.valueOf(FLDS[0]).equals(USR.id())==true)
				{
					indexsender = a;
					
					try 
					{
						float value = Float.valueOf(parametros[2]);
						int idreccheck = Integer.valueOf(parametros[1]);
						if (value<0f)
						{
							SendMessage SM = new SendMessage(idchat, "Hackeando Mastercard...");
							SM.parseMode(ParseMode.Markdown);
							TB.execute(SM);
							return false;
						}
						if (value<0f)
						{
							SendMessage SM = new SendMessage(idchat, "Hackeando Visa...");
							SM.parseMode(ParseMode.Markdown);
							TB.execute(SM);
							return false;
						}
						if (value<0.00001f)
						{
							SendMessage SM = new SendMessage(idchat, "El minimo establecido es [0.00001]...");
							SM.parseMode(ParseMode.Markdown);
							TB.execute(SM);
							return false;
						}
					} catch (Exception E)
					{
						SendMessage SM = new SendMessage(idchat, "Error en parametro...");
						SM.parseMode(ParseMode.Markdown);
						TB.execute(SM);
						return false;
					}
					
					if (Float.valueOf(parametros[2])<=Float.valueOf(FLDS[3]))
					{
						
						float mybalance = Float.valueOf(FLDS[3]);
						float palbalance=0f;
						boolean encounter = false;
						
						for (int b=1;b<Wallets.size();b++)
						{
							if (Integer.valueOf(Wallets.get(b).split("%")[1]).equals(Integer.valueOf(parametros[1])))
							{
								palbalance = Float.valueOf(Wallets.get(b).split("%")[3]);
								indexreceiver=b;
								encounter = true;
								break;
							}
						}
						
						if (encounter==true)
						{
							
							String IdSender = Wallets.get(indexsender).split("%")[0];
							String WalletSender = Wallets.get(indexsender).split("%")[1];
							String UserSender = Wallets.get(indexsender).split("%")[2];
							
							String IdReceiver = Wallets.get(indexreceiver).split("%")[0];
							String WalletReceiver = Wallets.get(indexreceiver).split("%")[1];
							String UserReceiver = Wallets.get(indexreceiver).split("%")[2];
							
							if (indexsender.equals(indexreceiver)==true)
							{
								SendMessage SM = new SendMessage(idchat, "Alcanzando la singularidad cosmica...");
								SM.parseMode(ParseMode.Markdown);
								TB.execute(SM);
								return false;
							}
							
							//IDUSER + "%" + IDWALLET + "%" + USUARIO + "%" + BALANCE
							mybalance = mybalance - Float.valueOf(parametros[2]);
							palbalance = palbalance + Float.valueOf(parametros[2]);
							Wallets.set(indexsender,IdSender + "%" + WalletSender + "%" + UserSender + "%" +mybalance);
							Wallets.set(indexreceiver,IdReceiver + "%" + WalletReceiver + "%" + UserReceiver + "%" +palbalance);
							
							String CompleteBlock="";
							
							for (int c=0;c<Wallets.size();c++)
							{
								CompleteBlock = CompleteBlock + Wallets.get(c) + "\n";
							}
							
							
							try {
								Files.delete(P);
								Files.createFile(P);
								Files.write(P,CompleteBlock.getBytes(),StandardOpenOption.APPEND);
								SendMessage SM = new SendMessage(idchat, "Transferencia registrada...");
								SM.parseMode(ParseMode.Markdown);
								TB.execute(SM);
								return true;}
							catch (IOException e) {
								
							} 
							
							
						} else 
						{
							SendMessage SM = new SendMessage(idchat, "Wallet inexistente...");
							SM.parseMode(ParseMode.Markdown);
							TB.execute(SM);
							return false;
						}
						
						
					} else 
					{
						SendMessage SM = new SendMessage(idchat, "Fondos insuficientes...");
						SM.parseMode(ParseMode.Markdown);
						TB.execute(SM);
						return false;
					}
				} 
				
				
				
				
			} 
			
			
		} 
		return false;
		
	}
	
	public static void main(String[] args) {
		
		setFiles();
		
		TB = new TelegramBot("412865955:AAEkOfXNdi0TOpamfIux9JK14uitFs8cWWQ");
		while (next) {
			
			GetUpdates GU = new GetUpdates();
			boolean ConectionAccepted = false;
			List<Update> MyList=null;
			while (ConectionAccepted==false){
			try{
			MyList = TB.execute(GU).updates();
			ConectionAccepted=true;
			} catch (Exception E)
			{
				ConectionAccepted=false;
				try {
					Thread.sleep(1000);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
			}
			}
			
			if (MyList!=null && MyList.size()!=0){
			int offset = 0;
			for (int a = 0; a < MyList.size(); a++) {

				if (MyList.get(a).message()!=null && MyList.get(a).message().text()!=null && MyList.get(a).message().text().startsWith("."))
				{
					Message MSG = MyList.get(a).message();
					long _groupid = MSG.chat().id();
					User _user = MSG.from();
					
					
					if (MSG.text().toLowerCase().contains(".help")) showhelp(_groupid);
					if (MSG.text().toLowerCase().contains(".wallet")) createwallet(MyList.get(a).message().from().id(),_groupid,_user);
					if (MSG.text().toLowerCase().contains(".index")) index(_groupid, _user);
					if (MSG.text().toLowerCase().contains(".transfer")) transfer(_groupid, _user, MSG);
					if (MSG.text().toLowerCase().contains(".ping")) ping(_groupid);
					
					
				}
				
				offset = MyList.get(a).updateId() + 1;
				if (MyList.get(a).message()!=null){
				System.out.println(MyList.get(a).message().text());}
				GetUpdates RegisterUpdates = new GetUpdates().limit(1).timeout(1).offset(offset);
				TB.execute(RegisterUpdates);

			}
			}
		}

		

	}



	public static void ping(long _groupid) {
		
		SendMessage SM = new SendMessage(_groupid, "Capitali$t PONG");
		SM.parseMode(ParseMode.Markdown);
		TB.execute(SM);
		
	}

}
