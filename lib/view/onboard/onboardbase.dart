import 'package:flutter/material.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';
import 'package:appescolar/core/theme/app_button_styles.dart';
import 'package:appescolar/core/theme/app_text_style.dart';

class Onboardbase extends StatelessWidget {
  const Onboardbase(
      {super.key,
      required this.titulo,
      required this.descricao,
      required this.imagem,
      required this.botaoPressionado,
      required this.paginaAtual,
      required this.totalPagina,
      required this.pageController});

  final String titulo;
  final String descricao;
  final Widget imagem;
  final VoidCallback botaoPressionado;
  final PageController pageController;
  final int paginaAtual;
  final int totalPagina;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Padding(
        padding: const EdgeInsets.fromLTRB(20, 60, 20, 20),
        child: Column(
          //  mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Container(
              width: 70,
              height: 70,
              decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  color: Color(0xffffffff),
                  image: DecorationImage(
                      image: AssetImage('assets/logo/logoCompleto.png'),
                      fit: BoxFit.contain)),
            ),
            SizedBox(
              height: 20,
            ),
            Align(
              alignment: Alignment.centerLeft,
              child: Text(titulo, style: AppTextStyle.tituloPrincipal),
            ),
            const SizedBox(height: 30),
            Expanded(
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20.0),
                child: Center(child: imagem),
              ),
            ),
            const SizedBox(height: 20),
            Text(descricao, style: AppTextStyle.textoGrande),
            const SizedBox(height: 20),
            SizedBox(
              width: double.infinity,
              height: 60,
              child: ElevatedButton(
                  onPressed: botaoPressionado,
                  style: AppBtn.botaoPretoBranco,
                  child: Text(
                    'CONTINUAR',
                    style: TextStyle(
                        color: Color(0xFF000000),
                        fontSize: 20,
                        fontFamily: 'Montserrat',
                        fontWeight: FontWeight.bold),
                  )),
            ),
            const SizedBox(height: 20),
            Align(
              alignment: Alignment.bottomCenter,
              child: Padding(
                padding: const EdgeInsets.only(bottom: 20.0),
                child: SmoothPageIndicator(
                  controller: pageController,
                  count: totalPagina,
                  effect: const ExpandingDotsEffect(
                    activeDotColor: Color(0xFF000000),
                    dotColor: Color(0xD9D9D9FF),
                    dotHeight: 8,
                    dotWidth: 8,
                    spacing: 8.0,
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
