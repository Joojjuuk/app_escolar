
import 'package:appescolar/view/user/login/login.dart';
import 'package:flutter/material.dart';
import 'package:appescolar/core/theme/app_text_style.dart';
import 'package:appescolar/core/theme/app_button_styles.dart';
class Sign extends StatefulWidget {
  const Sign({super.key});

  @override
  State<Sign> createState() => _SignState();
}

class _SignState extends State<Sign> {
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
                'Cadastrar',
                style: AppTextStyle.tituloPrincipal,
              ),
              SizedBox(height: 10),
              //texto "n tem conta"
          
              Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                Text('Já tem uma conta?',
                    style: AppTextStyle.textoDescricao,
                    textAlign: TextAlign.center),
                const SizedBox(width: 6),
                GestureDetector(
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => Login(),
                        ));
                  },
                  child: Text('Entrar',
                      style: AppTextStyle.textoLoginClicavel,
                      textAlign: TextAlign.center),
                )
              ]),
              SizedBox(height: 20),
              Form(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      //input email/ra
                      Text(
                        'Nome Completo',
                        style: AppTextStyle.textoDescricao,
                      ),
                      SizedBox(height: 8),
                      TextFormField(
                        decoration: AppBtn.bordaInput,
                      ),
                      SizedBox(height: 20),
                      Text(
                        'Email',
                        style: AppTextStyle.textoDescricao,
                      ),
                      SizedBox(height: 8),
                      TextFormField(
                        decoration: AppBtn.bordaInput,
                      ),
                      SizedBox(height: 20),
                      Text(
                        'Data de Nascimento',
                        style: AppTextStyle.textoDescricao,
                      ),
                      TextFormField(
                        obscureText: true,
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
                      SizedBox(height: 20),
                      Text(
                        'Senha',
                        style: AppTextStyle.textoDescricao,
                      ),
                      SizedBox(height: 8),
                      TextFormField(
                        obscureText: true,
                        decoration: AppBtn.bordaInput,
                      ),
                    ],
                  )),
              SizedBox(height: 10,),
          
          
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
              SizedBox(height: 20),
            ],
          ),
        ),
      ),
    );
  }
}