package com.nvn.mylife.Broadcast;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.widget.Toast;

import com.nvn.mylife.Services.NotifyService;

public class AutostartService extends BroadcastReceiver {
    @Override
    public void onReceive(Context context, Intent intent) {
/*        if (intent.getAction().equalsIgnoreCase(Intent.ACTION_AIRPLANE_MODE_CHANGED)){
            Intent intentService = new Intent(context, NotifyService.class);
            context.startService(intentService);

            Toast.makeText(context, "AIRPLANE MODE", Toast.LENGTH_LONG).show();
        }*/
    }
}
