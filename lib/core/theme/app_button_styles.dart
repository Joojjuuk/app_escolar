import 'package:flutter/material.dart';
import 'package:appescolar/core/constants/app_colors.dart';

class AppBtn {
  // BOTOES (onboard)
  static ButtonStyle botaoPretoBranco = ElevatedButton.styleFrom(
    backgroundColor: Colors.white,
    foregroundColor: Colors.black,
    shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(10),
        side: const BorderSide(color: Colors.black, width: 2)),
    elevation: 4,
  );

  //Botoes (Demais telas)
  static ButtonStyle botaoAzul = ElevatedButton.styleFrom(
    backgroundColor: AppColors.lightBlueBtn,
    foregroundColor: AppColors.lightBlueBtn,
    shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(10),
        side: const BorderSide(color: Colors.lightBlueAccent, width: 2)),
    elevation: 4,
  );

  //Border dos Inputs
  static InputDecoration bordaInput = InputDecoration(
    border: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10),
      borderSide: BorderSide(color: AppColors.whiteBord),
    ),
    focusedBorder: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10),
      borderSide: BorderSide(color: AppColors.whiteBord),
    ),
    enabledBorder: OutlineInputBorder(
      borderRadius: BorderRadius.circular(10),
      borderSide: BorderSide(color: AppColors.whiteBord),
    ),
  );
}
