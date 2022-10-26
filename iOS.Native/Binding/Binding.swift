//
//  Binding.swift
//  Binding
//

import Foundation
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
}
