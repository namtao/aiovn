package com.nvn.mylife.Entities;

public class Video {
    int anh;
    String tenPhim;

    public Video(int anh, String tenPhim) {
        this.anh = anh;
        this.tenPhim = tenPhim;
    }

    public int getAnh() {
        return anh;
    }

    public void setAnh(int anh) {
        this.anh = anh;
    }

    public String getTenPhim() {
        return tenPhim;
    }

    public void setTenPhim(String tenPhim) {
        this.tenPhim = tenPhim;
    }
}
