package com.nvn.mylife.Entities;

public class AlphabeEntity {
    private String upperCase, lowerCase, example;

    public AlphabeEntity(String upperCase, String lowerCase, String example) {
        this.upperCase = upperCase;
        this.lowerCase = lowerCase;
        this.example = example;
    }

    public String getUpperCase() {
        return upperCase;
    }

    public void setUpperCase(String upperCase) {
        this.upperCase = upperCase;
    }

    public String getLowerCase() {
        return lowerCase;
    }

    public void setLowerCase(String lowerCase) {
        this.lowerCase = lowerCase;
    }

    public String getExample() {
        return example;
    }

    public void setExample(String example) {
        this.example = example;
    }
}
