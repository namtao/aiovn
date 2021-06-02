package com.sql;

import java.io.File;
import java.io.IOException;
import java.net.Inet4Address;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.List;

public class ImportFile {
    public static List<File> moveAndRenameFile(File dir) {
        ArrayList<File> rtnFiles = new ArrayList<File>();
        Path temp = null;

        File[] files = dir.listFiles();

        for (File file : files) {

            if (file.isDirectory()) {
                rtnFiles.addAll(moveAndRenameFile(file));

            } else {
                if (file.getName().endsWith((".pdf"))) {
                    System.out.println("file: " + file.getAbsolutePath());

                    // create folder
                    try {
                        String pathDir = "D:/ADDJ/a/";
                        String str = file.getName();
                        String[] arr = new String[10];
                        arr = str.split("\\.");
                        for (int i = 0; i < arr.length - 2; i++) {
                            pathDir = pathDir + "/" + arr[i];
                        }
                        Path path = Paths.get(pathDir);
                        Files.createDirectories(path);

                        //move file
                        temp = Files.move(Paths.get(file.getAbsolutePath()), Paths.get(pathDir + "/" + file.getName()), StandardCopyOption.REPLACE_EXISTING);
                        System.out.println("Directory is created!");

                    } catch (IOException e) {
                        System.err.println("Failed to create directory!" + e.getMessage());
                    }

                    rtnFiles.add(file);
                }
            }
        }

        return rtnFiles;
    }

    public static String getIpAdress() throws UnknownHostException {
        InetAddress ip= InetAddress.getLocalHost();
        return ip.getHostAddress();
    }

    public static void main(String[] args) throws IOException {
        //ImportFile.moveAndRenameFile(new File("C:\\ADDJ\\a"));
        System.out.println(ImportFile.getIpAdress());
    }
}

