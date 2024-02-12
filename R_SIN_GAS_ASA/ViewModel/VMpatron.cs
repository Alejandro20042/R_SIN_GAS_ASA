using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace R_SIN_GAS_ASA.ViewModel
{
        public class VMpatron : BaseViewModel
        {
            #region VARIABLES
            double _Peso;
            double _Altura;

        string _Texto;

            string _Imagen;

            bool _ImcSeleccionado;
            bool _FcnSeleccionado;

            int _latidosSegundos;
            string _frecuenciaCardiacaResultado;
        #endregion


        #region OBJETOS 
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
            public string FrecuenciaResultado
            {
                get { return _frecuenciaCardiacaResultado; }
                set { SetValue(ref _frecuenciaCardiacaResultado, value); }
            }

            public int LatidosSegundos
            {
                get { return _latidosSegundos; }
                set { SetValue(ref _latidosSegundos, value); }
            }

            public string Imagen
            {
                get { return _Imagen; }
                set { SetValue(ref _Imagen, value); }
            }
            public double Peso
            {
                get { return _Peso; }
                set { SetValue(ref _Peso, value); }

            }
            public double Altura
            {
                get { return _Altura; }
                set { SetValue(ref _Altura, value); }
            }

            public bool IMCSeleccionar
            {
                get { return _ImcSeleccionado; }
                set
                {
                    SetValue(ref _ImcSeleccionado, value);
                    OnPropertyChanged(nameof(Activador));
                }
            }

            public bool FCNSeleccionar
            {
                get { return _FcnSeleccionado; }
                set
                {
                    SetValue(ref _FcnSeleccionado, value);
                    OnPropertyChanged(nameof(Activador));
                }
            }

            #endregion

             bool Activador => FCNSeleccionar;


        public void Calcular()
        {
            double peso = Peso;
            double altura = Altura;

            double resultado = peso / (altura * altura);
            

            if (FCNSeleccionar != true)
            {
                if (resultado < 18.5)
                {
                    Imagen = " https://i.ibb.co/xHsdmKW/comprobar-1.png";
                    Texto = " peso insuficiente.";
                    
                }
                else if (resultado >= 18.5 && resultado < 24.9)
                {
                    Imagen = " https://i.ibb.co/xHsdmKW/comprobar-1.png";
                    Texto = "normal o saludable.";
                }
                else if (resultado >= 25 && resultado < 29.9)
                {
                    Imagen = " https://i.ibb.co/wL298fr/crisis.png";
                    Texto = "sobrepeso";
                }
                else if (resultado >= 30.0)
                {
                    Imagen = " https://i.ibb.co/wL298fr/crisis.png";
                    Texto = "obesidad";
                }

            }
            else
            {
                int frecuenciaCardiaca = LatidosSegundos * 4;

                FrecuenciaResultado = $"Frecuencia Cardiaca: {frecuenciaCardiaca} latidos por minuto";

                if (frecuenciaCardiaca < 60)
                {
                    FrecuenciaResultado += " (FC Baja)";
                    Imagen = " https://i.ibb.co/wL298fr/crisis.png";
                }
                else if (frecuenciaCardiaca >= 60 && frecuenciaCardiaca <= 100)
                {
                    FrecuenciaResultado += " (FC Normal)";
                    Imagen = " https://i.ibb.co/xHsdmKW/comprobar-1.png";
                }
                else
                {
                    FrecuenciaResultado += " (FC Alta)";
                    Imagen = "  https://i.ibb.co/wL298fr/crisis.png";
                }
                


            }
        }

        public ICommand ProcesoCalcularCommand => new Command(Calcular);
    }
}

