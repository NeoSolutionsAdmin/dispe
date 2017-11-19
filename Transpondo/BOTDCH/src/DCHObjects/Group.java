package DCHObjects;

import java.io.Serializable;
import java.util.ArrayList;

import com.pengrad.telegrambot.TelegramBot;

import Main.Init;

public class Group implements Serializable {

	
	private static final long serialVersionUID = 1L;
	public Long Telegram_UID;
	public ArrayList<User> ListadoDeUsuarios;
	public String TelephoneNumber;
	public int AdminID;
	
	public Group(Long UID, int p_AdminID)
	{
		ListadoDeUsuarios =  new ArrayList<User>();
		Telegram_UID = UID;
		AdminID = p_AdminID;
		
	
		
	}
	
	

}
