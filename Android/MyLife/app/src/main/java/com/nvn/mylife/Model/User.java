package com.nvn.mylife.Model;

import java.io.Serializable;

public class User implements Serializable {
    String name, address;
    int age;

    public User() {
    }

    public User(String name, int age, String address) {
        this.name = name;
        this.address = address;
        this.age = age;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }
}
