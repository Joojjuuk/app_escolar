import 'dart:async';
import 'package:appescolar/view/onboard/onboard.dart';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:appescolar/view/home/home.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({super.key});

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  @override
  void initState() {
    super.initState();
    Timer(const Duration(milliseconds: 2500), () async {
      final see = await SharedPreferences.getInstance();
      final seeOnboard = see.getBool('seeOnboard') ?? false;

      if (mounted) {
        if (seeOnboard) {
          Navigator.pushReplacement(
              context, MaterialPageRoute(builder: (context) => Home()));
        } else {
          Navigator.pushReplacement(
              context, MaterialPageRoute(builder: (context) => Onboard()));
        }
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: Image.asset('assets/logo/splashScreenLogo.gif'),
      ),
    );
  }
}
