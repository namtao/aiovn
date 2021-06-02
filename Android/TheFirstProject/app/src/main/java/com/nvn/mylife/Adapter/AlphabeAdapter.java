package com.nvn.mylife.Adapter;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.view.LayoutInflater;

import com.nvn.mylife.Fragment.AlphabePager;
import com.nvn.mylife.Entities.AlphabeEntity;
import com.nvn.mylife.R;

//Adapter dùng để tạo ra danh sách cho layout_alphabe tiếp nhận vào các view con
//Adapter dùng ChuCaiFragment_Pager làm mẫu để put dữ liệu vào
public class AlphabeAdapter extends FragmentStatePagerAdapter {
    Context context;
    LayoutInflater inflater;

    public static AlphabeEntity[] alphabeEntityList ={new AlphabeEntity("A","a","Animal"),
            new AlphabeEntity("B","b","Black"),
            new AlphabeEntity("C","c","Close"),
            new AlphabeEntity("D","d","Daddy"),
            new AlphabeEntity("E","e","Enjoy"),
            new AlphabeEntity("F","f","Family"),
            new AlphabeEntity("G","g","Good"),
            new AlphabeEntity("H","h","Hello"),
            new AlphabeEntity("I","i","Issue"),
            new AlphabeEntity("J","j","Juice"),
            new AlphabeEntity("K","k","Know"),
            new AlphabeEntity("L","l","Love"),
            new AlphabeEntity("M","m","Mother"),
            new AlphabeEntity("N","n","Nothing"),
            new AlphabeEntity("O","o","Open"),
            new AlphabeEntity("P","p","Pretty"),
            new AlphabeEntity("Q","q","Quiet"),
            new AlphabeEntity("R","r","Right"),
            new AlphabeEntity("S","s","Software"),
            new AlphabeEntity("T","t","Thanks"),
            new AlphabeEntity("U","u","Understand"),
            new AlphabeEntity("V","v","Vehicle"),
            new AlphabeEntity("W","w","World"),
            new AlphabeEntity("X","x","Xenon"),
            new AlphabeEntity("Y","y","Young"),
            new AlphabeEntity("Z","z","Zoom")};

        public AlphabeAdapter(FragmentManager fm, Context context) {
        super(fm);
        this.context=context;
    }

    @Override
    public int getCount() {
        return alphabeEntityList.length;
    }

    //đổ dữ liệu vào
    @Override
    public Fragment getItem(int i) {
        Bundle bundle = new Bundle();
        bundle.putString("Upper Case", alphabeEntityList[i].getUpperCase());
        bundle.putString("Lower Case", alphabeEntityList[i].getLowerCase());
        bundle.putString("Example", alphabeEntityList[i].getExample());
        AlphabePager fragment= new AlphabePager();
        fragment.setArguments(bundle);
        return fragment;
    }

}


