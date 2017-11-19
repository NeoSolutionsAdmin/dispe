package DCHObjects;

import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;


public class Server implements Runnable {
	public boolean Running=true;
	public ServerSocket MyServer;
	public ArrayList<Socket> SocketsPool;
 public void run()
 {
	 try{
	 Thread.sleep(5000);} catch (Exception E){}
	 System.out.println("Ïniciando Servidor de escucha SMS...");
	 try{
	 MyServer =  new ServerSocket(40000);
	 System.out.println("Server iniciado...");
	 System.out.println("Iniciando pool...");
	 SocketsPool =  new ArrayList<Socket>();
	 System.out.println("Pool iniciado...");
	 
	 } catch (Exception E)
	 {
		 System.out.println("Error al iniciar servidor en puerto 40K");
	 }
	 
	 while (Running==true)
	 {
		 Socket S = null;
		 try{
			 Thread.sleep(5000);
		 System.out.println("En espera de conexión...");
		 S = MyServer.accept();
		 if (S.isConnected()==true)
		 {
			 System.out.println("Conexion Aceptada...");
			 System.out.println("Seteando timeout a 10 segundos");
			 System.out.println("Agregando conexión a pool de sockets");
			 SocketsPool.add(S);
			 
			 Thread.sleep(1000);
			 System.out.println("iniciando Thread de cliente");
			 ClientServer CS = new ClientServer();
			 CS.CliSocket = S;
			 Thread T =  new Thread(CS);
			 T.run();
			 
 
		 }
		 } catch (Exception e) {
			 System.out.print("Error al iniciar una conexión");
		}
	 }
 } 
}
