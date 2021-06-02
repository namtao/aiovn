package com.nvn.mylife.Adapter;

import android.content.Context;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

import com.nvn.mylife.Activity.VideoYoutube;
import com.nvn.mylife.Entities.Video;
import com.nvn.mylife.R;

public class VideoAdapter  extends RecyclerView.Adapter<VideoAdapter.ViewHolder>{
    List<Video> list_video;
    Context context;

    public VideoAdapter(Context context,List<Video> list_video) {
        this.context=context;
        this.list_video = list_video;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        LayoutInflater layoutInflater = LayoutInflater.from(viewGroup.getContext());
        View view=layoutInflater.inflate(R.layout.item_video,viewGroup,false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder viewHolder, int i) {
        Video video = list_video.get(i);
        final int dem=i;
        viewHolder.img_video.setImageResource(video.getAnh());
        viewHolder.tv_video.setText(video.getTenPhim());
        viewHolder.itemView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                VideoYoutube.i=dem;
                Intent intent= new Intent(view.getContext(),VideoYoutube.class);
                view.getContext().startActivity(intent);
            }
        });
    }

    @Override
    public int getItemCount() {
        return list_video.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {

        public ImageView img_video;
        public TextView tv_video;

        public ViewHolder(View itemView) {
            super(itemView);
            img_video = itemView.findViewById(R.id.img_video);
            tv_video = itemView.findViewById(R.id.tv_video);
        }
    }


}
