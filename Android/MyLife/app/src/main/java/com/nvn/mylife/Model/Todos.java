package com.nvn.mylife.Model;

public class Todos {
    private int id;
    private int userId;
    private String title;
    private boolean comleted;

    public Todos(int id, int userId, String title, boolean comleted) {
        this.id = id;
        this.userId = userId;
        this.title = title;
        this.comleted = comleted;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public boolean isComleted() {
        return comleted;
    }

    public void setComleted(boolean comleted) {
        this.comleted = comleted;
    }

    @Override
    public String toString() {
        return "Todos{" +
                "id=" + id +
                ", userId=" + userId +
                ", title='" + title + '\'' +
                ", comleted=" + comleted +
                '}';
    }
}
