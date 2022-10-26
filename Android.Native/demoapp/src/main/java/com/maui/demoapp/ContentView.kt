package com.maui.demoapp

import android.app.Activity
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material.Button
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import com.maui.binding.Binding
import com.maui.binding.StringCallback
import androidx.compose.runtime.getValue
import androidx.compose.runtime.setValue // only if using var

@Composable
fun ContentView() {
    val context = LocalContext.current as Activity
    var result by remember { mutableStateOf<String?>(null) }

    Column(Modifier.fillMaxSize(), verticalArrangement = Arrangement.Center, horizontalAlignment = Alignment.CenterHorizontally) {
        result?.let {
            Text(it)
        } ?: run {
            Button(onClick = {
                result = "Loading ..."
                Binding().async(context, listOf("Hello", "world!"), StringCallbackImpl {
                    result = it
                })
            }) {
                Text("Async")
            }
        }

        Button(onClick = {
            Binding().openPDF(context, "Sample PDF", "https://dagrs.berkeley.edu/sites/default/files/2020-01/sample.pdf")
        }) {
            Text("Open PDF")
        }
    }
}

class StringCallbackImpl(val callback: (String?) -> Unit) : StringCallback {
    override fun onResult(result: String) {
        callback(result)
    }
}