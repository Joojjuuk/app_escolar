import 'package:appescolar/view/user/forgot_password/verify_code.dart';
import 'package:flutter/material.dart';
import 'package:appescolar/core/theme/app_text_style.dart';
import 'package:appescolar/core/theme/app_button_styles.dart';

class ForgotPassword extends StatefulWidget {
  const ForgotPassword({super.key});

  @override
  State<ForgotPassword> createState() => _ForgotPasswordState();
}

class _ForgotPasswordState extends State<ForgotPassword> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Padding(
        padding: EdgeInsets.all(20),
        child: SingleChildScrollView(
          child: Column(
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
              SizedBox(height: 10),
              //texto "n tem conta"

              SizedBox(height: 20),
              Form(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      //input email/ra
                      Text(
                        'Email institucional',
                        style: AppTextStyle.textoDescricao,
                      ),
                      SizedBox(height: 8),
                      TextFormField(
                        decoration: AppBtn.bordaInput,
                      ),
                      SizedBox(height: 20),
                      Text(
                        'RA',
                        style: AppTextStyle.textoDescricao,
                      ),
                      SizedBox(height: 8),
                      TextFormField(
                        obscureText: true,
                        decoration: AppBtn.bordaInput,
                      ),
                    ],
                  )),
              SizedBox(height: 20),
              //botao

              SizedBox(
                  width: double.infinity,
                  height: 60,
                  child: ElevatedButton(
                    onPressed: () {},
                    style: AppBtn.botaoAzul,
                    child: Text('ENTRAR', style: AppTextStyle.textBtn),
                  )),

              GestureDetector(
                onTap: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => VerifyCode(),
                      ));
                },
                child: Text('Cadastrar',
                    style: AppTextStyle.textoLoginClicavel,
                    textAlign: TextAlign.center),
              )
            ],
          ),
        ),
      ),
    );
  }
}

