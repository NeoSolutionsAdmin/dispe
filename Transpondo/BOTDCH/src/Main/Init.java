package Main;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.ObjectOutputStream;
import java.nio.file.CopyOption;
import java.nio.file.Files;
import java.nio.file.LinkOption;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.EmptyStackException;
import java.util.List;
import java.util.Locale;

import javax.annotation.processing.ProcessingEnvironment;

import org.omg.PortableInterceptor.AdapterManagerIdHelper;

import com.google.gson.Gson;
import com.google.gson.JsonSerializer;
import com.pengrad.telegrambot.TelegramBot;
import com.pengrad.telegrambot.model.Message;
import com.pengrad.telegrambot.model.Update;
import com.pengrad.telegrambot.model.User;
import com.pengrad.telegrambot.request.GetUpdates;
import com.pengrad.telegrambot.request.SendMessage;
import com.pengrad.telegrambot.response.GetUpdatesResponse;

import DCHObjects.Group;
import DCHObjects.Server;

public class Init {
	
	
	public static TelegramBot TB; 
	public static ArrayList<Group> ListadoDeGrupos;
	public static String OS;
	public static String ConfigFile;
	public static String ConfigFileBackup;
	public static Boolean ConfigIsEmpty = false;
	public static Boolean TriggerMainLoop = false; 
	public static int previousoffset = -1;
	 
	public static String GetCurrentDate()
	{
		DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
		Calendar cal = Calendar.getInstance(Locale.getDefault());
		return dateFormat.format(cal.getTime());
	}
	
	
	public static void linuxmessage(String Message) 
	{
		OS = CheckSO();
		if (OS.contains("linux")==true) 
		{
			try{
			Runtime.getRuntime().exec("wall -n " + Message);} catch (Exception e) {}
		}
	}
	
	public static void main(String args[])
	{
		
		DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
		Calendar cal = Calendar.getInstance();
		
		linuxmessage("Arrancando sistema");
		
		System.out.println("Arrancando Sistema... Fecha: " + dateFormat.format(cal.getTime()));
		System.out.println("Iniciando ShutdownHOOK...");
		linuxmessage("Iniciando HOOK");
		
		Runtime RT = Runtime.getRuntime();
		RT.addShutdownHook(new Thread(new Runnable() {
			
			@Override
			public void run() {
				System.out.println("Terminando programa... Fecha: " + dateFormat.format(cal.getTime()));
				linuxmessage("Finalizando programa");
			}
		}));

		try {
			linuxmessage("Arranca en 20 seg");
		System.out.println("Arranca en 20 segundos");
			Thread.sleep(10000);
			System.out.println("Arranca en 10 segundos");
			linuxmessage("Arrancando en 10 seg");
			Thread.sleep(10000);
			System.out.println("Arrancando...");
			linuxmessage("Arrancando...");
			
		
		} catch (Exception e) 
		{
			
		}
		
		TB = new TelegramBot("487450082:AAFZaJTteXuzZURiIUU-_mrvVGUQctce3Oc");
		GetUpdates GU = new GetUpdates();
		GetUpdatesResponse GUR = TB.execute(GU);
		
		 List<Update> LU = GUR.updates();
		
			linuxmessage("Descartando buffer");
		 System.out.println("Descartando buffer...");
		 
		 if (LU.size()>0)
		 {
			 for (int a=0;a<LU.size();a++)
			 {
				 GetUpdates TGU = new GetUpdates();
				 TGU.offset((LU.get(a).updateId()+1));
				 TGU.limit(1);
				 TB.execute(TGU);
					linuxmessage("Descartando: " + LU.get(a).message().text());
				 System.out.println("Descartando...[" + LU.get(a).message().text() + "]");
				 
			 }
		 }
		 
		
		 System.out.println("Preparando buffer de lista...");
		ListadoDeGrupos = new ArrayList<>();
		System.out.println("Checkeando sistema Operativo...");
		OS = CheckSO();
		try{
		if (OS.contains("win")==true)
		{
			Runtime.getRuntime().exec("cls");
		} else 
		{
			Runtime.getRuntime().exec("clear");
			final String ANSI_CLS = "\u001b[2J";
	        final String ANSI_HOME = "\u001b[H";
	        System.out.print(ANSI_CLS + ANSI_HOME);
	        System.out.flush();
		}
		} catch (Exception E)
		{
			System.out.println(E.getMessage());
		}
		System.out.println("Sistema Ooperativo detectado:" + OS);
		System.out.println("ChequeandoDB...");
		CheckFS();
		if (ConfigIsEmpty==true)
		{
			System.out.println("Creando Base de datos nueva...");
			try{
			Gson GSON = new Gson();
			FileOutputStream FO =  new FileOutputStream(ConfigFile);
			FO.write(GSON.toJson(ListadoDeGrupos).getBytes());
			FO.close();
			System.out.println("Base de datos creada...");
			} catch (Exception E)
			{
				System.out.println("No se pudo crear el archivo de configuracion...");
			}
			
			
		} else 
		{
			try {
				System.out.println("Leyendo base de datos...");
				byte[] enc = Files.readAllBytes(Paths.get(ConfigFile));
				String Getted = new String(enc);
				Group[] G = new Gson().fromJson(Getted, Group[].class);
				System.out.println("Cargando Grupos...");
				for (int a=0;a<G.length;a++)
				{
					ListadoDeGrupos.add(G[a]);
					if (G[a].TelephoneNumber!=null){
					System.out.println(G[a].TelephoneNumber);
					linuxmessage("Cargando: " + G[a].TelephoneNumber);
					} else 
					{
						System.out.println("Grupo:" + G[a].Telegram_UID + " no tiene numero de Teléfono seteado");
					}
				}
				System.out.println("Información en la base de datos cargada con exito...");
				System.out.println("Preparando loop principal...");
				TriggerMainLoop = true;
				
			} catch (Exception e) {
				// TODO Auto-generated catch block
				System.out.println("No se pudo leer la base de datos...");
				System.out.println("Terminando el programa...");
				TriggerMainLoop = false;
			}
			
			
			System.out.println("Iniciando Thread Server...");
			Thread T =  new Thread(new Server());
			T.start();
			
			
			if (TriggerMainLoop==true)
			{
			System.out.println("Iniciando Loop principal...");
			} else 
			{
				System.out.println("No se puede iniciar loop principal...");
			}
			
			
			Thread H = new Thread(new Runnable() {
				
				@Override
				public void run() {
					System.out.println(" ");
					String Symbol = "<>";
					while (TriggerMainLoop==true)
					{
						if (Symbol.contains("<>"))
						{
							Symbol = "><";
						} else 
						{
							Symbol = "<>";
						}
						System.out.print("\rChequeando Updates [" + Symbol + "]");
						CheckAndSend();				
						System.out.print("\rChequeando Updates [" + Symbol + "]");
					}
					
				}
			});
			H.start();
			
			
			
		}
	}
	
	public static void CheckAndSend()
	{
		
		GetUpdates t_GU =  new GetUpdates();
		t_GU.limit(1);
		if (previousoffset!=-1)
		{
			t_GU.offset(previousoffset+1);
		}
		
		GetUpdatesResponse UpdateResponse = TB.execute(t_GU);
		if (UpdateResponse!=null)
		{
				if (UpdateResponse.isOk()==true)
				{
					if (UpdateResponse.updates().size()>0)
					{
						
						Update t_Update = UpdateResponse.updates().get(0);
						previousoffset=t_Update.updateId();
						
						System.out.println("Procesando Update offset=" + previousoffset);
						UpdateInterpeter(t_Update);
					} else 
					{
						waitme(2L);
					}
				}		else 
				{
					waitme(2L);
				}
				
				
		} else 
		{
			waitme(2L);
		}
		
		
	}
	public static boolean UpdateInterpeter(Update p_Update)
	{
		 
		if (p_Update.message()==null)
		{
			return false;
		}
		
		Message M = p_Update.message();
		Long GroupID = M.chat().id();
		if (M==null)
		{
			return false;
		} else 
		{
			if (M.text()==null)
			{
				return false;
			}
		}
		String Text = M.text();
		Integer UserId = M.from().id();
		String[] Comandos = Text.toLowerCase().split(" ");
		int GroupIndex = SearchGroup(GroupID);
		SendMessage SM;
		User user = p_Update.message().from();
		
		
		if (Comandos.length>0)
		{
			
			if (Comandos[0].contains("!inscribir"))
			{
				if (GroupIndex!=-1)
				{
					Talk(GroupID, "El grupo ya esta inscripto.");
					return false;
				}else 
				{
					ListadoDeGrupos.add(new Group(GroupID,UserId));
					Talk(GroupID, "El grupo se inscribio con éxito");
					
				saveDBS();
				return true;
				}
			}
			
			if (GroupIndex!=-1)
			{
				if (Comandos[0].contains("!hola") && Comandos[2]!=null)
				{
					DCHObjects.User tUser = SearchUser(GroupIndex, UserId);
					if (tUser!=null)
					{
						Talk(GroupID, "Hola " + tUser.Name + ", ya estas registrado en el sistema");
						return false;
						
					} else {
					ListadoDeGrupos.get(GroupIndex).ListadoDeUsuarios.add(new DCHObjects.User(user.id(), Comandos[2]));
					Talk(GroupID, "Hola " + Comandos[2] + ", acabas de ser registrado al sistema");
					saveDBS();
					return true;
					}
					
				} 
			}
						
			if (GroupIndex!=-1)
			{
				if (Comandos[0].contains("!telefono") && Comandos[1]!=null)
				{
					if (ListadoDeGrupos.get(GroupIndex).AdminID==UserId)
					{
						ListadoDeGrupos.get(GroupIndex).TelephoneNumber=Comandos[1];
						Talk(GroupID,"Teléfono seteado");
						saveDBS();
						return true;
					} else 
					{
						Talk(GroupID, "Las intrusiones al sistema son ilegales");
						return false;
					} 
				} else 
				{
					Talk(GroupID, "Faltan parametros en el comando");
					return false;
				}
			} 
			
			return false;
			
		} else 
		{
			return false;
		}
	}
	public static void saveDBS()
	{
		Path CF = Paths.get(ConfigFile);
		Path CFBK = Paths.get(ConfigFileBackup);
		try {
		Files.copy(CF,CFBK,StandardCopyOption.REPLACE_EXISTING);
		Files.delete(CF);
		Files.createFile(CF);
		File F = new File(ConfigFile);
		FileOutputStream FOS = new FileOutputStream(F);
		Gson G = new Gson();
		FOS.write(G.toJson(ListadoDeGrupos, ListadoDeGrupos.getClass()).getBytes());
		FOS.close();
		} catch (Exception E)
		{
			System.out.println("error");
		}
	}
	public static Group SearchTelephone(String Phone)
{
	Group result = null;
	for (int a=0;a<ListadoDeGrupos.size();a++)
	{
		
		if (ListadoDeGrupos.get(a).TelephoneNumber!=null && ListadoDeGrupos.get(a).TelephoneNumber.contains(Phone)==true)
		{
			result = ListadoDeGrupos.get(a);
			break;
		}
	}
	return result;
	}
	public static int SearchGroup(Long IdGroup)
	{
		int result=-1;
		for (int a=0;a<ListadoDeGrupos.size();a++)
		{
			if (ListadoDeGrupos.get(a).Telegram_UID.equals(IdGroup))
			{
				result = a;
				break;
			}
		}
		return result;
	}
	public static DCHObjects.User SearchUser(Integer GroupIndex, Integer UserID)
	{
		DCHObjects.User Result = null;
		for (int a=0;a<ListadoDeGrupos.get(GroupIndex).ListadoDeUsuarios.size();a++)
		{
			if (ListadoDeGrupos.get(GroupIndex).ListadoDeUsuarios.get(a).UserId.equals(UserID))
			{
				Result = ListadoDeGrupos.get(GroupIndex).ListadoDeUsuarios.get(a);
				break;
			}
			
		}
		return Result;
	}
	public static void Talk(Long ChatID,String Text )
	{
		SendMessage SM =  new SendMessage(ChatID, "[" + GetCurrentDate() + "]" + Text);
		TB.execute(SM);
	}
	public static void waitme(Long seconds)
	{
		Long Seconds = seconds*1000L;
		try {
		Thread.sleep(Seconds);
		} catch (Exception E)
		{
			System.out.println("No se puede esperar");
		}
	}
    public static void CheckFS()
    {
    	Boolean DirectoryOK=false;
		Boolean FileOK=false;
		
		String PathDirectoryFile;
		String PathConfigFile;
		String PathConfigFileBackup;
    	
    	if (OS.equals("windows"))
    	{
    		PathDirectoryFile="C:\\ConfigDCHBot";
    		PathConfigFile = "C:\\ConfigDCHBot\\SDBS.java";
    		PathConfigFileBackup = "C:\\ConfigDCHBot\\SDBSBackup.java";
    	} else 
    	{
    		PathDirectoryFile="/ConfigDCHBot";
    		PathConfigFile = "/ConfigDCHBot/SDBS.java";
    		PathConfigFileBackup = "/ConfigDCHBot/SDBSBackup.java";
    	}
    	
    	ConfigFile = PathConfigFile;
    	ConfigFileBackup = PathConfigFileBackup;
    	
    	Path PD = Paths.get(PathDirectoryFile);
		Path PF = Paths.get(PathConfigFile);
		
		if (Files.exists(PD,LinkOption.NOFOLLOW_LINKS)==true) DirectoryOK=true;
		if (Files.exists(PF,LinkOption.NOFOLLOW_LINKS)==true) FileOK=true;
		
		if (DirectoryOK==false)
		{
			File Directory = new File(PathDirectoryFile);
			try{
			Directory.mkdir();
			} catch (Exception E)
			{
				System.out.println("No se pudo crear el direcotrio de configuracin");
			}
		}
		
		if (FileOK==false)
		{
			try{
			File ConfigFile = new File(PathConfigFile);
			ConfigFile.createNewFile();
			ConfigIsEmpty = true;
			} catch (Exception E)
			{
				System.out.println("No se pudo crear el archivo de configuracion");
			}
		}
		
    }
	public static String CheckSO()
	{
		String SO = System.getProperty("os.name").toLowerCase();
		if (SO.contains("win")==true)
		{
			return "windows";
		} else 
		{
			return "linux";
		}
		
	}
	

}
