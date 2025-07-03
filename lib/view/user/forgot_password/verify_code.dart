import 'package:appescolar/core/theme/app_button_styles.dart';
import 'package:appescolar/core/theme/app_text_style.dart';
import 'package:flutter/material.dart';
import 'package:pinput/pinput.dart';

class VerifyCode extends StatefulWidget {
  const VerifyCode({super.key});

  @override
  State<VerifyCode> createState() => _VerifyCodeState();
}

final defaultPinTheme = PinTheme(
  width: 56,
  height: 56,
  textStyle: TextStyle(
      fontSize: 20,
      color: Color.fromRGBO(30, 60, 87, 1),
      fontWeight: FontWeight.w600),
  decoration: BoxDecoration(
    border: Border.all(color: Color.fromRGBO(234, 239, 243, 1)),
    borderRadius: BorderRadius.circular(20),
  ),
);

class _VerifyCodeState extends State<VerifyCode> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Padding(
        padding: EdgeInsets.all(20),
        child: SingleChildScrollView(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              //logo
              SizedBox(height: 20),
              Container(
                alignment: Alignment.center,
                height: 70,
                width: 70,
                child: Image.asset('assets/logo/logoCompleto.png'),
              ),
              SizedBox(height: 50),
              //titulo
              Text(
                'Esqueci a senha',
                style: AppTextStyle.tituloPrincipal,
              ),
              SizedBox(height: 15),
              Text(
                'Enviamos um link de redefinição para puxarEmail. '
                'Digite o código de 5 dígitos mencionado no e-mail',
                style: AppTextStyle.textoDescricao,
                textAlign: TextAlign.left,
              ),
              //texto "n tem conta"
              SizedBox(height: 30),
              Pinput(),
              SizedBox(
                height: 30,
              ),
              SizedBox(
                  height: 60,
                  width: double.infinity,
                  child: ElevatedButton(
                      onPressed: () {},
                      style: AppBtn.botaoAzul,
                      child: Text('ENVIAR', style: AppTextStyle.textBtn)))
            ],
          ),
        ),
      ),
    );
  }
}
