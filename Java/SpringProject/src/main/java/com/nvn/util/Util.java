package com.nvn.util;

import org.springframework.web.servlet.support.ServletUriComponentsBuilder;
import org.springframework.web.util.UriComponentsBuilder;

public class Util {
	public static String getUrl() {
		UriComponentsBuilder builder = ServletUriComponentsBuilder.fromCurrentRequest();
        String context = builder.buildAndExpand().getPath();
        String[] list= context.split("/");
        return list[1];
	}
}
