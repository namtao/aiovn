package com.nvn.mylife.Adapter;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.view.LayoutInflater;

import com.nvn.mylife.Fragment.PaintPager;
import com.nvn.mylife.R;

public class PaintAdapter extends FragmentStatePagerAdapter {
    Context context;
    LayoutInflater inflater;
    public  int[] ds_nen={
            R.drawable.anh20,
            R.drawable.anh22,
            R.drawable.anh24,
            R.drawable.anh25,
            R.drawable.anh26,
            R.drawable.anh27,
            R.drawable.anh28,
            R.drawable.anh29,
            R.drawable.anh52,
            R.drawable.anh53,
            R.drawable.anh57,
            R.drawable.anh58,
            R.drawable.anh61,
            R.drawable.anh63,
            R.drawable.anh64
    };

    public PaintAdapter(FragmentManager fm, Context context) {
        super(fm);
        this.context=context;
    }

    @Override
    public int getCount() {
        return ds_nen.length;
    }

    //đổ dữ liệu vào
    @Override
    public Fragment getItem(int i) {
        Bundle bundle = new Bundle();
        bundle.putInt("Image",ds_nen[i]);
        PaintPager fragment= new PaintPager();
        fragment.setArguments(bundle);
        return fragment;
    }

}
