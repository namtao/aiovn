package com.nvn.mylife.Entities;

public class Setting {
    int icon;
    String content;

    public Setting() {
    }

    public Setting(int icon, String content) {
        this.icon = icon;
        this.content = content;
    }

    public int getIcon() {
        return icon;
    }

    public void setIcon(int icon) {
        this.icon = icon;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }
}
