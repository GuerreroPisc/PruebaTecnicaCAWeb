# BrotliBundle
Brotli can reduce file sizes by up to 30% more than gzip.

This is a simple bundle with Brotli compression that falls back to Gzip and deflate

## Installation

You can download this bundle in the [NuGet](https://www.nuget.org/packages/Brotli.Bundle/).

## How to use

You can use this like the current bundle

```
/* JS */
bundles.Add(new BrotliScriptBundle("~/bundles/jqueryval", new JsMinify()).Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));
                
//CDN
bundles.Add(new BrotliScriptBundle("~/bundles/jquery",
                "http://code.jquery.com/jquery-2.1.4.min.js"));

/* CSS */                

bundles.Add(new BrotliStyleBundle("~/Content/themes/base/css", new CssMinify()).Include(
                "~/Content/themes/base/jquery.ui.core.css",
                "~/Content/themes/base/jquery.ui.resizable.css",
                "~/Content/themes/base/jquery.ui.selectable.css",
                "~/Content/themes/base/jquery.ui.accordion.css",
                "~/Content/themes/base/jquery.ui.autocomplete.css",
                "~/Content/themes/base/jquery.ui.button.css",
                "~/Content/themes/base/jquery.ui.dialog.css",
                "~/Content/themes/base/jquery.ui.slider.css",
                "~/Content/themes/base/jquery.ui.tabs.css",
                "~/Content/themes/base/jquery.ui.datepicker.css",
                "~/Content/themes/base/jquery.ui.progressbar.css",
                "~/Content/themes/base/jquery.ui.theme.css"));
                
//CDN
bundles.Add(new BrotliStyleBundle("~/Content/bootstrap",
                "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"));                
```

## Thanks

Thanks to [nolleto](https://github.com/nolleto) (Author of [GzipBundle]((https://github.com/nolleto/GzipBundle/))

Thanks to [XieJJ99](https://github.com/XieJJ99) (Author of [Brotli.Net](https://github.com/XieJJ99/brotli.net))