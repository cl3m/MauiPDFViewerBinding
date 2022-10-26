//
//  ContentView.swift
//  DemoApp
//
//  Created by Clem on 25.10.22.
//

import SwiftUI
import Binding

struct ContentView: View {
    @State var result: String?
    var body: some View {
        VStack(spacing: 20) {            
            if let result {
                Text(result)
            } else {
                Button("Async") {
                    result = "Loading ..."
                    SwiftBinding().async(parameters: ["Hello","world!"]) { result in
                        self.result = result
                    }
                }
            }
            Button("Open PDF") {
                SwiftBinding().openPDF(title: "Sample PDF", url: "https://dagrs.berkeley.edu/sites/default/files/2020-01/sample.pdf")
            }
        }
        .padding()
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
