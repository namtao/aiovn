package com.sql;

public class Convert {
    String str;
    String sql;

    public Convert(String str, String sql) {
        this.str = str;
        this.sql = sql;
    }

    public String getStr() {
        return str;
    }

    public void setStr(String str) {
        this.str = str;
    }

    public String getSql() {
        return sql;
    }

    public void setSql(String sql) {
        this.sql = sql;
    }
}
