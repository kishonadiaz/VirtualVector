using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVector.ThreeJsWrapper
{
    [ClassInterface(ClassInterfaceType.AutoDual)]

    [ComVisible(true)]
    public class Builder
    {
        WebView2 webView;
        String data = "import * as THREE from  \"three\"; \n" +
            "export function main(){\n" +
            "var geometry = new THREE.BoxGeometry(1, 1, 1)\n"+
            "var material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });\n" +
            "var cube = new THREE.Mesh(geometry, material);\n" +
            "return cube\n}";
        public Builder(WebView2 _web) { 
            
            webView = _web;
        
        }
        public String build()
        {
            if (webView == null) return "";
            return  data;

        }
        

    }
}
