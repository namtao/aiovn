package com.nvn.mylife.Fragment;

import android.content.res.AssetManager;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.io.IOException;
import java.io.InputStream;

import com.nvn.mylife.R;

public class InfoFragment extends Fragment {
    TextView tv_tt;
    String line;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view= inflater.inflate(R.layout.fragment_info,container,false);
        tv_tt=view.findViewById(R.id.tv_thongtin);
        AssetManager assetManager= getActivity().getAssets();
        try {
            InputStream is= assetManager.open("thongtin.txt");
            int size=is.available();
            byte[] buffer= new byte[size];
            is.read(buffer);
            is.close();
            line= new String(buffer);
//            BufferedReader reader= new BufferedReader(new InputStreamReader(is,"UTF-8"));
//            while ((line=reader.readLine())!=null){
//                line+="\n";
//            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        tv_tt.setText(line);
        return view;
    }
}
