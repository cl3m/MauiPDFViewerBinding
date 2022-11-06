//
//  Binding.swift
//  Binding
//

import Foundation
import PDFKit
import SwiftUI

@objc(Binding)
public class SwiftBinding: NSObject {
    var callback: StringCallback?

    @objc
    public func async(parameters: [String], callback: @escaping StringCallback) {
        self.callback = callback
        DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
            self.callback?("\(parameters[0]) \(parameters[1])")
        }
    }

    @objc
    public func openPDF(title: String, url: String) {
        let controller = UIHostingController(rootView: PDFViewer(title: title, url: url))
        UIApplication.shared.keyWindow?.rootViewController?.present(controller, animated: true)
    }

    @objc
    public func createPDFView() -> UIView {
        let pdfView = PDFKit.PDFView()
        pdfView.autoScales = true
        return pdfView
    }

    @objc
    public func setPDFViewURL(view: UIView, url: String) {
        guard let url = URL(string: url), let pdfView = view as? PDFKit.PDFView else {
            return
        }
        DispatchQueue.global().async {
            let document = PDFDocument(url: url)
            DispatchQueue.main.async {
                pdfView.document = document
            }
        }
    }
}
