package DCHObjects;

import java.io.Serializable;

public class User implements Serializable {
	private static final long serialVersionUID = 1L;
	public Integer UserId;
	public String Name;
	
	public User(Integer p_UserId, String p_Name)
	{
	Name = p_Name;
	UserId = p_UserId;
	}

}
