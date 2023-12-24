using Brotli.Bundle;
using System.Web.Optimization;

namespace WebOlimp
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new BrotliScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-3.3.1.min.js",
                        "~/Scripts/owner/metodosGenericos.js"
                        ));

            bundles.Add(new BrotliScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery/jquery.validate.min.js",
                        "~/Scripts/modulos/additional-methods.owner.js"));
            bundles.Add(new BrotliScriptBundle("~/bundles/jqueryvalunobtrusive").Include(
                        "~/Scripts/jquery/jquery.validate.unobtrusive.min.js"));
            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new BrotliScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.8.3.min.js"));


            bundles.Add(new BrotliScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/js/popper.min.js",
                      "~/Scripts/bootstrap/js/bootstrap-4.4.1.min.js",
                      "~/Scripts/slimscroll_1.3.7/jquery.slimscroll.js"
                     ));

            bundles.Add(new BrotliScriptBundle("~/bundles/datatableslib/responsive").Include(
           "~/Scripts/datatables/dataTables.responsive.min.js"));

            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs").Include(
                     "~/Scripts/datatables/jquery.dataTables.min.js",
                       "~/Scripts/datatables/dataTables.bootstrap4.min.js"
                       ));

            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/buttons").Include(
                       "~/Scripts/datatables/dataTables.buttons.min.js",
                       "~/Scripts/datatables/buttons.bootstrap4.min.js"
                      ));
            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/buttons/jszip").Include(
                        "~/Scripts/datatables/jszip.min.js"
                      ));
            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/buttons/pdf").Include(
                         "~/Scripts/datatables/pdfmake.min.js"
                      ));
            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/buttons/vfsfonts").Include(
                          "~/Scripts/datatables/vfs_fonts.js"
                      ));
            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/buttons/html5").Include(
                         "~/Scripts/datatables/buttons.html5.min.js"
                      ));
            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/buttons/print").Include(
                         "~/Scripts/datatables/buttons.print.min.js"
                      ));
            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/buttons/colvis").Include(
                         "~/Scripts/datatables/buttons.buttons.colVis.min.js"
                      ));
            bundles.Add(new BrotliScriptBundle("~/bundles/datatablesjs/responsive").Include(
                      "~/Scripts/datatables/dataTables.responsive.min.js",
                      "~/Scripts/datatables/responsive.bootstrap4.min.js"));

            bundles.Add(new BrotliScriptBundle("~/bundles/bootstrap/select").Include(
                      "~/Scripts/selectpicker/bootstrap-select.min.js",
                      "~/Scripts/selectpicker/i18n/defaults-es_ES.min.js"
                     ));
            bundles.Add(new BrotliScriptBundle("~/bundles/jqueryrotate").Include(
                      "~/Scripts/jquery/jQueryRotate.min.js"
                     ));
            bundles.Add(new BrotliScriptBundle("~/bundles/fresco").Include(
                      "~/Scripts/fresco/fresco.min.js"));

            bundles.Add(new BrotliStyleBundle("~/Content/admin/vendor/select2").Include(
                  "~/Content/vendor/select2/css/select2.min.css"));

            bundles.Add(new BrotliScriptBundle("~/bundles/admin/vendor/select2").Include(
                      "~/Scripts/vendor/select2/js/select2.full.min.js"));

            bundles.Add(new BrotliScriptBundle("~/bundles/momentjs").Include(
                     "~/Scripts/moment.min.js"));

            bundles.Add(new BrotliScriptBundle("~/bundles/bootstrap/end").Include(
                     "~/Scripts/modulos/Configuration.js",
                       "~/Scripts/modulos/MetodosGenerico.js",
                      "~/Scripts/alert/sweetalert2.min.js",
                       "~/Scripts/alert/jquery-confirm.js"
                       ));

            bundles.Add(new BrotliScriptBundle("~/bundles/bootstrapdatepicker").Include(
                      "~/Scripts/datepicker/bootstrap-datepicker.min.js",
                      "~/Scripts/datepicker/locales/bootstrap-datepicker.es.min.js",
                      "~/Scripts/datepicker/custom-bootstrap-datepicker.js"
                      ));

            bundles.Add(new BrotliStyleBundle("~/Content/dropzonejs").Include(
                      "~/Content/dropzone/dropzone.min.css"
                      ));

            bundles.Add(new BrotliScriptBundle("~/bundles/dropzonejs").Include(
                        "~/Scripts/dropzone/dropzone.min.js"
                        ));

            bundles.Add(new BrotliScriptBundle("~/bundles/momentjslib").Include(
                       "~/Scripts/momentjs/moment.min.js"));



            bundles.Add(new BrotliStyleBundle("~/Content/css").Include(
                        "~/Content/alert/sweetalert2.min.css",
                         "~/Content/alert/jquery-confirm.css",
                      "~/Content/fontawesome/css/font-awesome.min.css",
                      "~/Content/bootstrap/css/bootstrap-4.4.1.min.css"
                      ));

            bundles.Add(new BrotliStyleBundle("~/Content/datatablesjs").Include(
                      "~/Content/datatables/dataTables.bootstrap4.min.css",
                       "~/Content/bootstrap/css/buttons.bootstrap4.min.css",
                      "~/Content/datatables/responsive.bootstrap4.min.css"));

            bundles.Add(new BrotliStyleBundle("~/Content/bootstrap/select").Include(
                     "~/Content/selectpicker/bootstrap-select.min.css"));

            bundles.Add(new BrotliStyleBundle("~/Content/fresco").Include(
                      "~/Content/fresco/fresco.min.css"));

            bundles.Add(new BrotliStyleBundle("~/Content/bootstrapdatepicker").Include(
                    "~/Content/datepicker/bootstrap-datepicker.min.css"
                    ));

            bundles.Add(new BrotliStyleBundle("~/Content/styles/owner").Include(
                      "~/Content/owner/mvpready-admin.min.css",
                      "~/Content/styles-web.min.css"));

            #region Login            

            bundles.Add(new BrotliScriptBundle("~/bundles/General").Include(
                      "~/Scripts/owner/mvpready-core.min.js",
                      "~/Scripts/owner/mvpready-helpers.min.js",
                      "~/Scripts/owner/mvpready-admin.min.js",
                      "~/Scripts/owner/mvpready-account.min.js"));
            #endregion

            #region Sede 
            bundles.Add(new BrotliScriptBundle("~/bundles/listaSede").Include(
                     "~/Scripts/modulos/sede/listaSede.js"));
            bundles.Add(new BrotliScriptBundle("~/bundles/crearSede").Include(
                     "~/Scripts/modulos/sede/crearSede.js"));
            bundles.Add(new BrotliScriptBundle("~/bundles/editarSede").Include(
                     "~/Scripts/modulos/sede/editarSede.js"));
            #endregion

            #region Complejo Polideportivo 
            bundles.Add(new BrotliScriptBundle("~/bundles/listaComplejoPolideportivo").Include(
                     "~/Scripts/modulos/complejoPolideportivo/listaComplejoPolideportivo.js"));
            bundles.Add(new BrotliScriptBundle("~/bundles/crearComplejoPolideportivo").Include(
                     "~/Scripts/modulos/complejoPolideportivo/crearComplejoPolideportivo.js"));
            bundles.Add(new BrotliScriptBundle("~/bundles/editarComplejoPolideportivo").Include(
                     "~/Scripts/modulos/complejoPolideportivo/editarComplejoPolideportivo.js"));
            #endregion

            BundleTable.EnableOptimizations = true;
        }
    }
}
