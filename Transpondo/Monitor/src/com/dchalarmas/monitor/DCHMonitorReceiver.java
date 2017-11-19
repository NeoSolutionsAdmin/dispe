package com.dchalarmas.monitor;
import java.util.ArrayList;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.telephony.SmsMessage;
import android.widget.Toast;



public class DCHMonitorReceiver extends BroadcastReceiver {
	
	public static ArrayList<DCHMessage> MessageList = new ArrayList<DCHMessage>();
	
	@Override
	public void onReceive(Context context, Intent intent) {
		// TODO Auto-generated method stub
		
		
		Bundle data  = intent.getExtras();

        Object[] pdus = (Object[]) data.get("pdus");

        for(int i=0;i<pdus.length;i++){
            SmsMessage smsMessage = SmsMessage.createFromPdu((byte[]) pdus[0]);

            String sender = smsMessage.getDisplayOriginatingAddress();
            //You must check here if the sender is your provider and not another one with same text.

            String messageBody = smsMessage.getMessageBody();
            String TelephoneNumber = smsMessage.getOriginatingAddress();

            DCHMessage M = new DCHMessage();
            M.Message = messageBody;
            M.Telephone = TelephoneNumber;
            
            Thread Thr =  new Thread(M);
            Thr.start();
            
            
            
            //Pass on the text to our listener.
            Toast T = Toast.makeText(context, messageBody + ":" + TelephoneNumber  , Toast.LENGTH_LONG);
    		T.show();
            
        }
		
	}

}
