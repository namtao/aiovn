package com.nvn.entities;

import javax.persistence.*;

@Entity
@Table(name = "TODOS")
public class Todos implements java.io.Serializable {

    private static final long serialVersionUID = 1L;

    private int id;
    private int userId;
    private String title;
    private String content;
    private boolean comleted;

    public Todos(int id, int userId, String title, String content, boolean comleted) {
        this.id = id;
        this.userId = userId;
        this.title = title;
        this.content=content;
        this.comleted = comleted;
    }

    public Todos() {

    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Id", unique = true, nullable = true)
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Column(name = "UserId", nullable = false)
    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    @Column(name = "Title", nullable = false)
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @Column(name = "Content", nullable = false)
    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    @Column(name = "Completed", nullable = false)
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
                ",conten='"+ content +'"'+
                ", comleted=" + comleted +
                '}';
    }
}

