package com.nvn.mylife.Entities;

public class ImageEntity {
    int stt;
    String url;
    String moTa;

    public ImageEntity(int stt, String url, String moTa) {
        this.stt = stt;
        this.url = url;
        this.moTa = moTa;
    }

    public int getStt() {
        return stt;
    }

    public void setStt(int stt) {
        this.stt = stt;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getMoTa() {
        return moTa;
    }

    public void setMoTa(String moTa) {
        this.moTa = moTa;
    }
}
