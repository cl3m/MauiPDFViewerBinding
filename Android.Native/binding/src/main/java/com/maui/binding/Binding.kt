package com.maui.binding

import android.app.Activity
import android.content.Context
import android.content.Intent
import android.view.View
import com.rajat.pdfviewer.PdfRendererView
import com.rajat.pdfviewer.PdfViewerActivity
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class Binding {
    private var callback: StringCallback? = null
    fun async(activity: Activity, parameters: List<String>, callback: StringCallback) {
        this.callback = callback
        GlobalScope.launch {
            delay(1000)
            this@Binding.callback?.onResult("${parameters[0]} ${parameters[1]}")
        }
    }

    fun openPDF(activity: Activity, title: String, url: String) {
        val intent = PdfViewerActivity.launchPdfFromUrl(activity.baseContext, url, title, directoryName = null, enableDownload = false)
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        activity.startActivity(intent)
    }

    fun createPDFView(context: Context): View {
        val pdfView = PdfRendererView(context)
        return pdfView
    }

    fun setPDFViewURL(view: View, url: String) {
        if (view is PdfRendererView) {
            view.initWithUrl(url)
        }
    }
}