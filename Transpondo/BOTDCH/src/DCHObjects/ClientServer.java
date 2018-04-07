package DCHObjects;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

import com.pengrad.telegrambot.model.request.InputContactMessageContent;

import Main.Init;

public class ClientServer implements Runnable {

	public Socket CliSocket;


	
	public void run() {
		InputStream in = null;
		try {
			in = CliSocket.getInputStream();
		} catch (Exception E) {

		}

		if (CliSocket != null) {
			try {
				String Cadena = "";
				while (in.available()==0){}
				
				while (CliSocket.isConnected() == true) {
					byte[] B = new byte[1];
					
					
					
					if (in.available()>0 && in.read(B, 0, 1  )>=0)
					{
						
						Cadena = Cadena + new String(B);
						
					} else 
					{
						Cadena = Cadena.trim();
						System.out.println("Cadena recibida: " + Cadena);
						Main.Init.linuxmessage("Cadena recibida:" + Cadena);
						Thread.sleep(1000);
						CliSocket.close();
						if (Cadena!="")
						{
							AnalyzeChain(Cadena);
						}
					}
				}
			} catch (Exception E) {
				System.out.println("Error: ********************************************");
				for (int a=0; a<E.getStackTrace().length;a++)
				{
					System.out.println("Clase:" + E.getStackTrace()[a].getClassName());
					System.out.println("Linea:" + E.getStackTrace()[a].getLineNumber());
					System.out.println("Metodo:" + E.getStackTrace()[a].getMethodName());
					System.out.println("Metodo:" + E.getStackTrace()[a].getMethodName());
					System.out.println("Error: Stack *********************** " + a);
					
				}
				System.out.println("Fin error: *************************************");
				System.out.println(E.getMessage());
			}
		}
	}

	private void AnalyzeChain(String p_Cadena)
	{
		String[] Ordenes;
		Ordenes = p_Cadena.split("\\+");
		for (int a=0;a<Ordenes.length;a++)
		{
			String[] Signals = Ordenes[a].split("\\-");
			if (Signals.length==2)
			{
				AnalyzeSignal(Signals[1], Signals[0]);
			}
		}
	}
	
	private void AnalyzeSignal(String Tel, String Message)
	{
		
		
		String T = Tel.trim();
		int offset = T.length()-7;
		T = T.substring(offset);
		Group G = Init.SearchTelephone(T);
		System.out.println("Se envia a nombre del telefono" + Tel);
		if (G!=null)
		{
			if (Message.toLowerCase().contains("alarma")){			
			Init.Talk(G.Telegram_UID, "DCH INFORMA: \n Alarma de robo \n Espere su llamado...");
			Init.linuxmessage("Alarma de robo:" + G.TelephoneNumber);
			}
			if (Message.toLowerCase().contains("corte")){			
				Init.Talk(G.Telegram_UID, "DCH INFORMA: \n Corte del suministro electrico...");
				Init.linuxmessage("Corte suministro electrico:" + G.TelephoneNumber);
				
				}
			if (Message.toLowerCase().contains("normalizado")){			
				Init.Talk(G.Telegram_UID, "DCH INFORMA: \n Suministro electrico normalizado...");
				Init.linuxmessage("Suministro electrico normalizao:" + G.TelephoneNumber);
				}
			if (Message.toLowerCase().contains("emergencia")){			
				Init.Talk(G.Telegram_UID, "DCH INFORMA: \n Emergencia medica \n Ambulancia en camino...");
				Init.linuxmessage("Emergencia medica:" + G.TelephoneNumber);
				}
			if (Message.toLowerCase().contains("alerta")){			
				Init.Talk(G.Telegram_UID, "DCH INFORMA: \n Sistema de mantenimiento de rutina... ");
				Init.linuxmessage("Mantenimiento rutinario:" + G.TelephoneNumber);
				}
		}
		
		
	}
}
