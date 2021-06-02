package com.nvn.mylife.Fragment;

import android.graphics.Bitmap;
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
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import com.nvn.mylife.Adapter.LibraryAdapter;
import com.nvn.mylife.R;

public class LibraryFragment extends Fragment {
    RecyclerView recyclerView;
    public static List<Bitmap> list= new ArrayList<>();
    LibraryAdapter libraryAdapter;
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view=inflater.inflate(R.layout.fragment_video,container,false);
        recyclerView=view.findViewById(R.id.list_phim);
        recyclerView.setHasFixedSize(true);

        //recycleview quản lí theo các dạng layout
        LinearLayoutManager mLayoutManager = new LinearLayoutManager(getContext(),LinearLayout.VERTICAL,false);
        recyclerView.setLayoutManager(mLayoutManager);

        //set adapter cho viewpager
        libraryAdapter = new LibraryAdapter(getContext(),list);
        recyclerView.setAdapter(libraryAdapter);
        Toast.makeText(getContext(), "Có "+ libraryAdapter.getItemCount()+ " hình ảnh", Toast.LENGTH_SHORT).show();

        //thay đổi ngay sau khi có sự thay đổi tác động đến viewpager
        libraryAdapter.notifyDataSetChanged();
        return view;
    }
}
