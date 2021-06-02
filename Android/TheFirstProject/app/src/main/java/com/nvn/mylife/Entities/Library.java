package com.nvn.mylife.Entities;

import android.widget.ImageView;

public class Library {
    ImageView imageView;

    public ImageView getImageView() {
        return imageView;
    }

    public void setImageView(ImageView imageView) {
        this.imageView = imageView;
    }

    public Library(ImageView imageView) {

        this.imageView = imageView;
    }
}
