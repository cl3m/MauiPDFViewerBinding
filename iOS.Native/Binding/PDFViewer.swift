//
//  PDFViewer.swift
//  Binding
//
//  Created by Clem on 25.10.22.
//

import Foundation
import PDFKit
import SwiftUI

struct PDFViewer: View {
    let title: String
    let url: String
    @Environment(\.presentationMode) var presentationMode
    
    var body: some View {
        NavigationView {
            PDFView(url: URL(string: url)!)
                .navigationTitle(title)
                .navigationBarTitleDisplayMode(.inline)
                .navigationBarItems(trailing:
                    Button("Done", action: {
                        presentationMode.wrappedValue.dismiss()
                    }).foregroundColor(.white)
                )
        }.onAppear {
            let appearance = UINavigationBarAppearance()
            appearance.backgroundColor = UIColor(red: 0.32, green: 0.17, blue: 0.83, alpha: 1.00)
            appearance.titleTextAttributes = [NSAttributedString.Key.foregroundColor: UIColor.white]
            UINavigationBar.appearance().tintColor = .white
            UINavigationBar.appearance().standardAppearance = appearance
            UINavigationBar.appearance().compactAppearance = appearance
            UINavigationBar.appearance().scrollEdgeAppearance = appearance
        }
    }
}


struct PDFView : UIViewRepresentable {
    let url: URL

    func makeUIView(context: Context) -> UIView {
        let pdfView = PDFKit.PDFView()
        pdfView.autoScales = true
        DispatchQueue.global().async {
            let document = PDFDocument(url: url)
            DispatchQueue.main.async {
                pdfView.document = document
            }
        }
        return pdfView
    }

    func updateUIView(_ uiView: UIView, context: Context) {
        // Empty
    }
}
