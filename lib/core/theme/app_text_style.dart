import 'package:flutter/material.dart';
import 'package:appescolar/core/constants/app_colors.dart';

class AppTextStyle{

  static const TextStyle tituloPrincipal = TextStyle(
    color: AppColors.blueTitle,
    fontSize: 40,
    fontFamily: 'AbrilFatFace',
    height: 1,
    fontWeight: FontWeight.bold
  );
  static const TextStyle tituloNoticias = TextStyle(
      color: AppColors.blackNewsTittle,
      fontSize: 17,
      fontFamily: 'AbrilFatFace',
      height: 1,
      fontWeight: FontWeight.bold
  );
  static const TextStyle textoGrande = TextStyle(
    color: AppColors.blackText,
    fontWeight: FontWeight.normal,
    fontFamily: 'Montserrat',
    height: 1.1,
    fontSize: 21,
  );

  static const TextStyle textoNormal = TextStyle(
    color: AppColors.blackText,
    fontWeight: FontWeight.normal,
    fontFamily: 'Montserrat',
    fontSize: 14,
  );

  static const TextStyle textoDescricao = TextStyle(
    color: AppColors.grayText,
    fontWeight: FontWeight.normal,
    fontFamily: 'Montserrat',
    fontSize: 14,
  );






}