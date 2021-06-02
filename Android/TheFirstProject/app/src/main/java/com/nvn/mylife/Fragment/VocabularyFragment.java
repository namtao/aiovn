package com.nvn.mylife.Fragment;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.nvn.mylife.R;

public class VocabularyFragment extends Fragment {
    TextView tv_tuvung;
    Button btn_tuvung;
    TextView o1h1, o2h1, o3h1, o4h1, o5h1, o1h2, o2h2, o3h2, o4h2, o5h2;
    EditText edt_tv;
    List<TextView> listTv;
    Map<String, String> map;
    List<String> listKeyset;

    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_vocabulary, container, false);

        init(view);

        action();

        return view;
    }

    public void init(View view) {
        tv_tuvung = view.findViewById(R.id.tv_tuvung);
        btn_tuvung = view.findViewById(R.id.btn_tuvung);
        o1h1 = view.findViewById(R.id.o1h1);
        o2h1 = view.findViewById(R.id.o2h1);
        o3h1 = view.findViewById(R.id.o3h1);
        o4h1 = view.findViewById(R.id.o4h1);
        o5h1 = view.findViewById(R.id.o5h1);
        o1h2 = view.findViewById(R.id.o1h2);
        o2h2 = view.findViewById(R.id.o2h2);
        o3h2 = view.findViewById(R.id.o3h2);
        o4h2 = view.findViewById(R.id.o4h2);
        o5h2 = view.findViewById(R.id.o5h2);
        edt_tv = view.findViewById(R.id.edt_tv);

        listTv = new ArrayList<TextView>();
        map = new HashMap<>();

        map.put("xin chào","hello");
        map.put("chào","hi");

        listTv.add(o1h1);
        listTv.add(o2h1);
        listTv.add(o3h1);
        listTv.add(o4h1);
        listTv.add(o5h1);
        listTv.add(o1h2);
        listTv.add(o2h2);
        listTv.add(o3h2);
        listTv.add(o4h2);
        listTv.add(o5h2);

/*        for (int i = 0; i < 5; i++) {
            listTv.get(i).setVisibility(View.VISIBLE);
        }

        o1h1.setText("0");
        o2h1.setText("1");
        o3h1.setText("2");
        o4h1.setText("3");
        o5h1.setText("4");
        o1h2.setText("5");
        o2h2.setText("6");
        o3h2.setText("7");
        o4h2.setText("8");
        o5h2.setText("9");*/

    }

    public void reset() {
        o1h1.setText("");
        o2h1.setText("");
        o3h1.setText("");
        o4h1.setText("");
        o5h1.setText("");
        o1h2.setText("");
        o2h2.setText("");
        o3h2.setText("");
        o4h2.setText("");
        o5h2.setText("");

        edt_tv.setText("");
    }

    public void random(){

    }

    public void action() {
        listKeyset=new ArrayList<>(map.keySet());

        btn_tuvung.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
/*                String text= o1h1.getText().toString()+o2h1.getText().toString()+
                        o3h1.getText().toString()+o4h1.getText().toString()+
                        o5h1.getText().toString()+o1h2.getText().toString()+
                        o2h2.getText().toString()+o3h2.getText().toString()+
                        o4h2.getText().toString()+o5h2.getText().toString();*/
                if (edt_tv.getText().toString().equals(map.get(tv_tuvung.getText().toString()))) {
                    listKeyset.remove(0);
                    tv_tuvung.setText(listKeyset.get(0));
                    reset();
                }
            }
        });
    }
}
