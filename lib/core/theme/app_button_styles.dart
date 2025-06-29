import 'package:flutter/material.dart';
import 'package:appescolar/core/constants/app_colors.dart';


class AppBtn{

  static ButtonStyle botaoPretoBranco = ElevatedButton.styleFrom(
    backgroundColor: Colors.white,
    foregroundColor: Colors.black,
    shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(5),
        side: const BorderSide(color: Colors.black, width: 2)),
    elevation: 4,
  );

  static ButtonStyle botaoAzul = ElevatedButton.styleFrom(
    backgroundColor: AppColors.lightBlueBtn,
    foregroundColor: AppColors.lightBlueBtn,
    shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(5),
        side: const BorderSide(width: 2)),
    elevation: 4,
  );



}