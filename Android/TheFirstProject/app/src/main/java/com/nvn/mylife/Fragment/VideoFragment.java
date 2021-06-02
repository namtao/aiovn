package com.nvn.mylife.Fragment;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;

import java.util.ArrayList;
import java.util.List;

import com.nvn.mylife.Adapter.VideoAdapter;
import com.nvn.mylife.Entities.Video;
import com.nvn.mylife.R;

public class VideoFragment extends Fragment {
    RecyclerView recyclerView;
    List<Video> list= new ArrayList<>();
    VideoAdapter videoAdapter;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view=inflater.inflate(R.layout.fragment_video,container,false);
        recyclerView=view.findViewById(R.id.list_phim);
        recyclerView.setHasFixedSize(true);
        add();
        LinearLayoutManager mLayoutManager = new LinearLayoutManager(getContext(),LinearLayout.VERTICAL,false);
        recyclerView.setLayoutManager(mLayoutManager);
        videoAdapter= new VideoAdapter(getContext(),list);
        recyclerView.setAdapter(videoAdapter);
        return view;
    }

    public void add(){
        list.add(new Video(R.drawable.ic_video,"Yết Kiêu"));
        list.add(new Video(R.drawable.ic_video,"Hai Chiếc rìu"));
        list.add(new Video(R.drawable.ic_video,"Cóc kiện trời"));
        list.add(new Video(R.drawable.ic_video,"Cô bé quàng khăn đỏ"));
        list.add(new Video(R.drawable.ic_video,"Sọ dừa"));
        list.add(new Video(R.drawable.ic_video,"Cây tre trăm đốt"));
        list.add(new Video(R.drawable.ic_video,"Sự tích Tích Chu"));
        list.add(new Video(R.drawable.ic_video,"Chú Cuội"));
        list.add(new Video(R.drawable.ic_video,"Thạch Sanh"));
        list.add(new Video(R.drawable.ic_video,"Tấm Cám"));
    }
}
