package com.dchalarmas.monitor;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

public class DCHMessage implements Runnable{
	
	public DCHMessage() {
	 super();
	}
	
	public Boolean Sendit = false;
	public String Message = "";
	public String Telephone = "";
	@Override
	public void run() {
		
		try {
	 Socket S = new Socket("190.105.214.230", 40000);
	 OutputStream OS = S.getOutputStream();
	 Telephone = Telephone.replace('+', '0');
	 Boolean indentificado = false;
	  
	 if (Message.toLowerCase().contains("alarma de robo")==true)
	  {
		  OS.write(("alarma"+"-"+Telephone).getBytes());
		  Thread.sleep(1000);
		  indentificado=true;
	  }
	 
	 if (Message.toLowerCase().contains("corte del suministro")==true)
	  {
		  OS.write(("corte"+"-"+Telephone).getBytes());
		  Thread.sleep(1000);
		  indentificado=true;
	  }
	 
	 if (Message.toLowerCase().contains("normalizado")==true)
	  {
		  OS.write(("normalizado"+"-"+Telephone).getBytes());
		  Thread.sleep(1000);
		  indentificado=true;
	  }
	 
	 if (Message.toLowerCase().contains("emergencia medica")==true)
	  {
		  OS.write(("emergencia"+"-"+Telephone).getBytes());
		  Thread.sleep(1000);
		  indentificado=true;
	  }
	 
	 if (indentificado==false)
	 {
		 OS.write(("alerta"+"-"+Telephone).getBytes());
		  Thread.sleep(1000);
		  indentificado=true;
	 }
	 
	 
	 
	 
	 } catch (Exception E) 
		{
		 
		}
		
	}
	
}
