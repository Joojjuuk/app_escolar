import 'package:appescolar/view/home/home.dart';
import 'package:flutter/material.dart';
import 'package:appescolar/view/onboard/onboardbase.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:smooth_page_indicator/smooth_page_indicator.dart';

class Onboard extends StatefulWidget {
  const Onboard({super.key});

  @override
  State<Onboard> createState() => _OnboardState();
}

class _OnboardState extends State<Onboard> {
  final PageController _pageController = PageController();

  @override
  void initState() {
    super.initState();
  }

  Future<void> _marcarVistoTela() async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.setBool('hasSeenOnboarding', true);
  }

  void _botaoPressionado() async {
    if (_pageController.page?.round() == onboardPag.length - 1) {
      await _marcarVistoTela();
      Navigator.of(context).pushReplacement(
        MaterialPageRoute(builder: (context) => const Home()),
      );
    } else {
      _pageController.nextPage(
        duration: const Duration(milliseconds: 500),
        curve: Curves.easeOut,
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Stack(
        children: [
          PageView.builder(
            controller: _pageController,
            itemCount: onboardPag.length,
            itemBuilder: (context, index) {
              final page = onboardPag[index];
              return Onboardbase(
                titulo: page.titulo,
                descricao: page.descricao,
                imagem: Image.asset(page.imagem),
                botaoPressionado: _botaoPressionado,
                totalPagina: onboardPag.length,
                pageController: _pageController,
                paginaAtual: 0,
              );
            },
          ),
        ],
      ),
    );
  }
}

class OnboardPages {
  final String titulo;
  final String descricao;
  final String imagem;

  OnboardPages(
      {required this.titulo, required this.descricao, required this.imagem});
}

final List<OnboardPages> onboardPag = [
  OnboardPages(
    titulo: "Bem-vindo\nao PEI Barão\nSustentabilidade!",
    descricao:
        "Descubra como pequenas ações \npodem transformar o mundo.\nNosso app é o primeiro passo\npara um futuro mais consciente.",
    imagem: 'assets/onboardingscreen/Tela1Planta.png',
  ),
  OnboardPages(
    titulo: "O que é o app PEI\nSustentabilidade?",
    descricao:
        "Aqui, você acompanha suas \ndoações de garrafas PET e \ntampinhas, vê as últimas ações \nda escola e fica por dentro das\nnovidades verdes do PEI Barão.",
    imagem: 'assets/onboardingscreen/Tela2Info.png',
  ),
  OnboardPages(
    titulo: "Faça a diferença!",
    descricao:
        "Doe, participe das campanhas e \nveja seu impacto crescer. Juntos, \npodemos fazer da escola um \nexemplo de sustentabilidade.",
    imagem: 'assets/onboardingscreen/Tela3Ajuda.png',
  ),
  OnboardPages(
    titulo: "Vamos nessa? 🌱",
    descricao:
        "Cadastre-se, faça login e comece \na jornada pela preservação do \nnosso planeta!",
    imagem: 'assets/onboardingscreen/Tela4Vamosla.png',
  ),
];
