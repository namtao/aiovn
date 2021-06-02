package com.nvn.mylife.Entities;

import android.graphics.Bitmap;
import android.view.View;

public class Screenshots {
    public static Bitmap takeScreenShot(View v){
        v.setDrawingCacheEnabled(true);
        v.buildDrawingCache(true);
        Bitmap b= Bitmap.createBitmap(v.getDrawingCache());
        v.setDrawingCacheEnabled(false);
        return b;
    }

    public static Bitmap takesScreenShotOfRootView(View view){
        return takeScreenShot(view.getRootView());
    }
}
