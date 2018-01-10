using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenuController : MonoBehaviour {

	// [SELECT LEVEL] Buttons
	public Button grassLand;
	public Button desertLand;
	public Button winterLand;
	public Button graveLand;
	public Button sciFiLand;
	// [SELECT VEHICLE] Buttons
	public Button car;
	public Button orc;
	public Button monster;
	// [SELECT UPGRADE] Buttons
	public Button Upgrade1;
	public Button Upgrade2;
	public Button Upgrade3;
	public Button Upgrade4;
	public Button Upgrade5;
	public Button Upgrade6;
	public Button Upgrade7;
	public Button Upgrade8;
	public Button Upgrade9;
	public Button Upgrade10;
	public Button Upgrade11;
	// [SELECT SOUND]
	public GameObject SoundOn;
	public GameObject SoundOff;
	public Button SoundAdd;
	public Button SoundMinus;
	// [SELECT MUSIC]
	public GameObject MusicOn;
	public GameObject MusicOff;
	public Button MusicAdd;
	public Button MusicMinus;

	// [SELECT LEVEL] Buttons text
	public Text grassLandText;
	public Text desertLandText;
	public Text winterLandText;
	public Text graveLandText;
	public Text sciFiLandText;
	// [SELECT VEHICLE] Buttons text
	public Text carText;
	public Text orcText;
	public Text monsterText;
	// [SELECT UPGRADE] Buttons text
	public Text Upgrade1Text;
	public Text Upgrade2Text;
	public Text Upgrade3Text;
	public Text Upgrade4Text;
	public Text Upgrade5Text;
	public Text Upgrade6Text;
	public Text Upgrade7Text;
	public Text Upgrade8Text;
	public Text Upgrade9Text;
	public Text Upgrade10Text;
	public Text Upgrade11Text;

	// [SELECT UPGRADE] Price text
	public Text upgradePrice1;
	public Text upgradePrice2;
	public Text upgradePrice3;
	public Text upgradePrice4;
	public Text upgradePrice5;
	public Text upgradePrice6;
	public Text upgradePrice7;
	public Text upgradePrice8;
	public Text upgradePrice9;
	public Text upgradePrice10;
	public Text upgradePrice11;

	// [MAIN MENU] prices
	public Text money;
	public Text money2;
	public Text money3;

	public Text HighScore;
	public String name;

	public Image SoundLevel1;
	public Image SoundLevel2;
	public Image SoundLevel3;
	public Image SoundLevel4;
	public Image SoundLevel5;
	public Image MusicLevel1;
	public Image MusicLevel2;
	public Image MusicLevel3;
	public Image MusicLevel4;
	public Image MusicLevel5;

	public Color SoundColorOn;
	public Color SoundColorOff;

	public GameObject mainMenuPanel;
	public GameObject selectUpgradePanel;

	// is it main menu?
	public bool levelsAvailable = false;

	// Saving info to array
	private int[] boughtLevel = new int[5];
	private int[] boughtVehicle = new int[3];
	private int[,] boughtUpgrade = new int[3,11];
	private int[] upgradePrices = new int[5];
	private int soundLevel = 5;
	private int musicLevel = 5;
	// Exits game
	public void ExitGame(){
		Application.Quit ();
	}

	void Start(){
		name = System.Environment.UserName;
		savePlayerScore ();

		if (!PlayerPrefs.HasKey ("PlayerSoundLevel"))
			PlayerPrefs.SetInt ("PlayerSoundLevel", 5);

		if (!PlayerPrefs.HasKey ("PlayerMusicLevel"))
			PlayerPrefs.SetInt ("PlayerMusicLevel", 5);

		for (int i = 0; i < 5; i++) {
			boughtLevel [i] = 0;
		}
		for (int i = 0; i < 3; i++) {
			boughtVehicle [i] = 0;
			for (int j = 0; j < 11; j++) {
				boughtUpgrade [i,j] = 0;
			}
		}
		upgradePrices [0] = 250;
		upgradePrices [1] = 1000;
		upgradePrices [2] = 5000;
		upgradePrices [3] = 25000;
		upgradePrices [4] = 100000;

		if(PlayerPrefs.GetInt("PlayerMoney") <= 0)
			PlayerPrefs.SetInt ("PlayerMoney", PlayerPrefs.GetInt ("PlayerMoney") + 500);
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Z)) {
			PlayerPrefs.SetInt ("PlayerMoney", PlayerPrefs.GetInt ("PlayerMoney") + 10000);
		}

		if (PlayerPrefs.HasKey ("CameFromGame")) {
			int cameFromGame = PlayerPrefs.GetInt ("CameFromGame");
			if (cameFromGame == 1) {
				mainMenuPanel.SetActive (false);
				selectUpgradePanel.SetActive (true);
			}
		}
		PlayerPrefs.SetInt ("CameFromGame", 0);

		// [SELECT SOUND_MUSIC]
		if (PlayerPrefs.HasKey ("PlayerSoundLevel"))
			soundLevel = PlayerPrefs.GetInt ("PlayerSoundLevel");
		if (PlayerPrefs.HasKey ("PlayerMusicLevel"))
			musicLevel = PlayerPrefs.GetInt ("PlayerMusicLevel");

		// [SELECT SOUND_MUSIC]
		if (soundLevel == 0) {
			SoundLevel1.color = SoundColorOff;
			SoundLevel2.color = SoundColorOff;
			SoundLevel3.color = SoundColorOff;
			SoundLevel4.color = SoundColorOff;
			SoundLevel5.color = SoundColorOff;
			SoundOn.SetActive (false);
			SoundOff.SetActive (true);
			SoundAdd.interactable = true;
			SoundMinus.interactable = false;
		} else if (soundLevel == 1) {
			SoundLevel1.color = SoundColorOn;
			SoundLevel2.color = SoundColorOff;
			SoundLevel3.color = SoundColorOff;
			SoundLevel4.color = SoundColorOff;
			SoundLevel5.color = SoundColorOff;
			SoundOn.SetActive (true);
			SoundOff.SetActive (false);
			SoundAdd.interactable = true;
			SoundMinus.interactable = true;
		} else if (soundLevel == 2) {
			SoundLevel1.color = SoundColorOn;
			SoundLevel2.color = SoundColorOn;
			SoundLevel3.color = SoundColorOff;
			SoundLevel4.color = SoundColorOff;
			SoundLevel5.color = SoundColorOff;
			SoundOn.SetActive (true);
			SoundOff.SetActive (false);
			SoundAdd.interactable = true;
			SoundMinus.interactable = true;
		} else if (soundLevel == 3) {
			SoundLevel1.color = SoundColorOn;
			SoundLevel2.color = SoundColorOn;
			SoundLevel3.color = SoundColorOn;
			SoundLevel4.color = SoundColorOff;
			SoundLevel5.color = SoundColorOff;
			SoundOn.SetActive (true);
			SoundOff.SetActive (false);
			SoundAdd.interactable = true;
			SoundMinus.interactable = true;
		} else if (soundLevel == 4) {
			SoundLevel1.color = SoundColorOn;
			SoundLevel2.color = SoundColorOn;
			SoundLevel3.color = SoundColorOn;
			SoundLevel4.color = SoundColorOn;
			SoundLevel5.color = SoundColorOff;
			SoundOn.SetActive (true);
			SoundOff.SetActive (false);
			SoundAdd.interactable = true;
			SoundMinus.interactable = true;
		} else {
			SoundLevel1.color = SoundColorOn;
			SoundLevel2.color = SoundColorOn;
			SoundLevel3.color = SoundColorOn;
			SoundLevel4.color = SoundColorOn;
			SoundLevel5.color = SoundColorOn;
			SoundOn.SetActive (true);
			SoundOff.SetActive (false);
			SoundAdd.interactable = false;
			SoundMinus.interactable = true;
		}

		if (musicLevel == 0) {
			MusicLevel1.color = SoundColorOff;
			MusicLevel2.color = SoundColorOff;
			MusicLevel3.color = SoundColorOff;
			MusicLevel4.color = SoundColorOff;
			MusicLevel5.color = SoundColorOff;
			MusicOn.SetActive (false);
			MusicOff.SetActive (true);
			MusicAdd.interactable = true;
			MusicMinus.interactable = false;
		} else if (musicLevel == 1) {
			MusicLevel1.color = SoundColorOn;
			MusicLevel2.color = SoundColorOff;
			MusicLevel3.color = SoundColorOff;
			MusicLevel4.color = SoundColorOff;
			MusicLevel5.color = SoundColorOff;
			MusicOn.SetActive (true);
			MusicOff.SetActive (false);
			MusicAdd.interactable = true;
			MusicMinus.interactable = true;
		} else if (musicLevel == 2) {
			MusicLevel1.color = SoundColorOn;
			MusicLevel2.color = SoundColorOn;
			MusicLevel3.color = SoundColorOff;
			MusicLevel4.color = SoundColorOff;
			MusicLevel5.color = SoundColorOff;
			MusicOn.SetActive (true);
			MusicOff.SetActive (false);
			MusicAdd.interactable = true;
			MusicMinus.interactable = true;
		} else if (musicLevel == 3) {
			MusicLevel1.color = SoundColorOn;
			MusicLevel2.color = SoundColorOn;
			MusicLevel3.color = SoundColorOn;
			MusicLevel4.color = SoundColorOff;
			MusicLevel5.color = SoundColorOff;
			MusicOn.SetActive (true);
			MusicOff.SetActive (false);
			MusicAdd.interactable = true;
			MusicMinus.interactable = true;
		} else if (musicLevel == 4) {
			MusicLevel1.color = SoundColorOn;
			MusicLevel2.color = SoundColorOn;
			MusicLevel3.color = SoundColorOn;
			MusicLevel4.color = SoundColorOn;
			MusicLevel5.color = SoundColorOff;
			MusicOn.SetActive (true);
			MusicOff.SetActive (false);
			MusicAdd.interactable = true;
			MusicMinus.interactable = true;
		} else {
			MusicLevel1.color = SoundColorOn;
			MusicLevel2.color = SoundColorOn;
			MusicLevel3.color = SoundColorOn;
			MusicLevel4.color = SoundColorOn;
			MusicLevel5.color = SoundColorOn;
			MusicOn.SetActive (true);
			MusicOff.SetActive (false);
			MusicAdd.interactable = false;
			MusicMinus.interactable = true;
		}

		if (levelsAvailable) {
			// GetPlayer's money
			int playerMoney = 0;
			if (PlayerPrefs.HasKey ("PlayerMoney"))
				playerMoney = PlayerPrefs.GetInt ("PlayerMoney");
			
			// [SELECT LEVEL] Retrieve player info
			if (PlayerPrefs.HasKey ("PlayerBoughtLevel1")) {
				boughtLevel [0] = PlayerPrefs.GetInt ("PlayerBoughtLevel1");
			}
			if (PlayerPrefs.HasKey ("PlayerBoughtLevel2")) {
				boughtLevel [1] = PlayerPrefs.GetInt ("PlayerBoughtLevel2");
			}
			if (PlayerPrefs.HasKey ("PlayerBoughtLevel3")) {
				boughtLevel [2] = PlayerPrefs.GetInt ("PlayerBoughtLevel3");
			}
			if (PlayerPrefs.HasKey ("PlayerBoughtLevel4")) {
				boughtLevel [3] = PlayerPrefs.GetInt ("PlayerBoughtLevel4");
			}
			if (PlayerPrefs.HasKey ("PlayerBoughtLevel5")) {
				boughtLevel [4] = PlayerPrefs.GetInt ("PlayerBoughtLevel5");
			}
			// [SELECT VEHICLE] Retrieve player info
			if (PlayerPrefs.HasKey ("PlayerBoughtVehicle1")) {
				boughtVehicle [0] = PlayerPrefs.GetInt ("PlayerBoughtVehicle1");
			}
			if (PlayerPrefs.HasKey ("PlayerBoughtVehicle2")) {
				boughtVehicle [1] = PlayerPrefs.GetInt ("PlayerBoughtVehicle2");
			}
			if (PlayerPrefs.HasKey ("PlayerBoughtVehicle3")) {
				boughtVehicle [2] = PlayerPrefs.GetInt ("PlayerBoughtVehicle3");
			}
			// [SELECT UPGRADE] Retrieve player info
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade1")) {
				boughtUpgrade [0, 0] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade1");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade2")) {
				boughtUpgrade [0, 1] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade2");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade3")) {
				boughtUpgrade [0, 2] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade3");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade4")) {
				boughtUpgrade [0, 3] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade4");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade5")) {
				boughtUpgrade [0, 4] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade5");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade6")) {
				boughtUpgrade [0, 5] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade6");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade7")) {
				boughtUpgrade [0, 6] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade7");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade8")) {
				boughtUpgrade [0, 7] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade8");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade9")) {
				boughtUpgrade [0, 8] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade9");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade10")) {
				boughtUpgrade [0, 9] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade10");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle1Upgrade11")) {
				boughtUpgrade [0, 10] = PlayerPrefs.GetInt ("PlayerVehicle1Upgrade11");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade1")) {
				boughtUpgrade [1, 0] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade1");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade2")) {
				boughtUpgrade [1, 1] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade2");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade3")) {
				boughtUpgrade [1, 2] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade3");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade4")) {
				boughtUpgrade [1, 3] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade4");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade5")) {
				boughtUpgrade [1, 4] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade5");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade6")) {
				boughtUpgrade [1, 5] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade6");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade7")) {
				boughtUpgrade [1, 6] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade7");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade8")) {
				boughtUpgrade [1, 7] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade8");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade9")) {
				boughtUpgrade [1, 8] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade9");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade10")) {
				boughtUpgrade [1, 9] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade10");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle2Upgrade11")) {
				boughtUpgrade [1, 10] = PlayerPrefs.GetInt ("PlayerVehicle2Upgrade11");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade1")) {
				boughtUpgrade [2, 0] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade1");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade2")) {
				boughtUpgrade [2, 1] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade2");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade3")) {
				boughtUpgrade [2, 2] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade3");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade4")) {
				boughtUpgrade [2, 3] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade4");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade5")) {
				boughtUpgrade [2, 4] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade5");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade6")) {
				boughtUpgrade [2, 5] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade6");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade7")) {
				boughtUpgrade [2, 6] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade7");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade8")) {
				boughtUpgrade [2, 7] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade8");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade9")) {
				boughtUpgrade [2, 8] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade9");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade10")) {
				boughtUpgrade [2, 9] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade10");
			}
			if (PlayerPrefs.HasKey ("PlayerVehicle3Upgrade11")) {
				boughtUpgrade [2, 10] = PlayerPrefs.GetInt ("PlayerVehicle3Upgrade11");
			}

			// [SELECT LEVEL] button text
			if (boughtLevel [0] == 0)
				grassLandText.text = "PURCHASE";
			else
				grassLandText.text = "SELECT";

			if (boughtLevel [1] == 0)
				desertLandText.text = "PURCHASE";
			else
				desertLandText.text = "SELECT";

			if (boughtLevel [2] == 0)
				winterLandText.text = "PURCHASE";
			else
				winterLandText.text = "SELECT";

			if (boughtLevel [3] == 0)
				graveLandText.text = "PURCHASE";
			else
				graveLandText.text = "SELECT";

			if (boughtLevel [4] == 0)
				sciFiLandText.text = "PURCHASE";
			else
				sciFiLandText.text = "SELECT";

			// [SELECT VEHICLE] button text
			if (boughtVehicle [0] == 0)
				carText.text = "PURCHASE";
			else
				carText.text = "SELECT";

			if (boughtVehicle [1] == 0)
				orcText.text = "PURCHASE";
			else
				orcText.text = "SELECT";

			if (boughtVehicle [2] == 0)
				monsterText.text = "PURCHASE";
			else
				monsterText.text = "SELECT";

			// [SELECT UPGRADE] button text
			int veh = PlayerPrefs.GetInt ("PlayerSelectVehicle");
			if (veh == 1) {
				if (boughtUpgrade [0, 0] == 5) {
					Upgrade1Text.text = "MAX";
					Upgrade1.interactable = false;
				} else {
					Upgrade1Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 0]];
					upgradePrice1.text = price.ToString ();
					if (playerMoney < price)
						Upgrade1.interactable = false;
					else
						Upgrade1.interactable = true;
				}

				if (boughtUpgrade [0, 1] == 5) {
					Upgrade2Text.text = "MAX";
					Upgrade2.interactable = false;
				} else {
					Upgrade2Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 1]];
					upgradePrice2.text = price.ToString ();
					if (playerMoney < price)
						Upgrade2.interactable = false;
					else
						Upgrade2.interactable = true;
				}

				if (boughtUpgrade [0, 2] == 5) {
					Upgrade3Text.text = "MAX";
					Upgrade3.interactable = false;
				} else {
					Upgrade3Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 2]];
					upgradePrice3.text = price.ToString ();
					if (playerMoney < price)
						Upgrade3.interactable = false;
					else
						Upgrade3.interactable = true;
				}

				if (boughtUpgrade [0, 3] == 5) {
					Upgrade4Text.text = "MAX";
					Upgrade4.interactable = false;
				} else {
					Upgrade4Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 3]];
					upgradePrice4.text = price.ToString ();
					if (playerMoney < price)
						Upgrade4.interactable = false;
					else
						Upgrade4.interactable = true;
				}

				if (boughtUpgrade [0, 4] == 5) {
					Upgrade5Text.text = "MAX";
					Upgrade5.interactable = false;
				} else {
					Upgrade5Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 4]];
					upgradePrice5.text = price.ToString ();
					if (playerMoney < price)
						Upgrade5.interactable = false;
					else
						Upgrade5.interactable = true;
				}

				if (boughtUpgrade [0, 5] == 5) {
					Upgrade6Text.text = "MAX";
					Upgrade6.interactable = false;
				} else {
					Upgrade6Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 5]];
					upgradePrice6.text = price.ToString ();
					if (playerMoney < price)
						Upgrade6.interactable = false;
					else
						Upgrade6.interactable = true;
				}

				if (boughtUpgrade [0, 6] == 5) {
					Upgrade7Text.text = "MAX";
					Upgrade7.interactable = false;
				} else {
					Upgrade7Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 6]];
					upgradePrice7.text = price.ToString ();
					if (playerMoney < price)
						Upgrade7.interactable = false;
					else
						Upgrade7.interactable = true;
				}

				if (boughtUpgrade [0, 7] == 5) {
					Upgrade8Text.text = "MAX";
					Upgrade8.interactable = false;
				} else {
					Upgrade8Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 7]];
					upgradePrice8.text = price.ToString ();
					if (playerMoney < price)
						Upgrade8.interactable = false;
					else
						Upgrade8.interactable = true;
				}

				if (boughtUpgrade [0, 8] == 5) {
					Upgrade9Text.text = "MAX";
					Upgrade9.interactable = false;
				} else {
					Upgrade9Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 8]];
					upgradePrice9.text = price.ToString ();
					if (playerMoney < price)
						Upgrade9.interactable = false;
					else
						Upgrade9.interactable = true;
				}

				if (boughtUpgrade [0, 9] == 5) {
					Upgrade10Text.text = "MAX";
					Upgrade10.interactable = false;
				} else {
					Upgrade10Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 9]];
					upgradePrice10.text = price.ToString ();
					if (playerMoney < price)
						Upgrade10.interactable = false;
					else
						Upgrade10.interactable = true;
				}

				if (boughtUpgrade [0, 10] == 5) {
					Upgrade11Text.text = "MAX";
					Upgrade11.interactable = false;
				} else {
					Upgrade11Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [0, 10]];
					upgradePrice11.text = price.ToString ();
					if (playerMoney < price)
						Upgrade11.interactable = false;
					else
						Upgrade11.interactable = true;
				}
			} else if (veh == 2) {
				if (boughtUpgrade [1, 0] == 5) {
					Upgrade1Text.text = "MAX";
					Upgrade1.interactable = false;
				} else {
					Upgrade1Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 0]];
					upgradePrice1.text = price.ToString ();
					if (playerMoney < price)
						Upgrade1.interactable = false;
					else
						Upgrade1.interactable = true;
				}

				if (boughtUpgrade [1, 1] == 5) {
					Upgrade2Text.text = "MAX";
					Upgrade2.interactable = false;
				} else {
					Upgrade2Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 1]];
					upgradePrice2.text = price.ToString ();
					if (playerMoney < price)
						Upgrade2.interactable = false;
					else
						Upgrade2.interactable = true;
				}

				if (boughtUpgrade [1, 2] == 5) {
					Upgrade3Text.text = "MAX";
					Upgrade3.interactable = false;
				} else {
					Upgrade3Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 2]];
					upgradePrice3.text = price.ToString ();
					if (playerMoney < price)
						Upgrade3.interactable = false;
					else
						Upgrade3.interactable = true;
				}

				if (boughtUpgrade [1, 3] == 5) {
					Upgrade4Text.text = "MAX";
					Upgrade4.interactable = false;
				} else {
					Upgrade4Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 3]];
					upgradePrice4.text = price.ToString ();
					if (playerMoney < price)
						Upgrade4.interactable = false;
					else
						Upgrade4.interactable = true;
				}

				if (boughtUpgrade [1, 4] == 5) {
					Upgrade5Text.text = "MAX";
					Upgrade5.interactable = false;
				} else {
					Upgrade5Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 4]];
					upgradePrice5.text = price.ToString ();
					if (playerMoney < price)
						Upgrade5.interactable = false;
					else
						Upgrade5.interactable = true;
				}

				if (boughtUpgrade [1, 5] == 5) {
					Upgrade6Text.text = "MAX";
					Upgrade6.interactable = false;
				} else {
					Upgrade6Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 5]];
					upgradePrice6.text = price.ToString ();
					if (playerMoney < price)
						Upgrade6.interactable = false;
					else
						Upgrade6.interactable = true;
				}

				if (boughtUpgrade [1, 6] == 5) {
					Upgrade7Text.text = "MAX";
					Upgrade7.interactable = false;
				} else {
					Upgrade7Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 6]];
					upgradePrice7.text = price.ToString ();
					if (playerMoney < price)
						Upgrade7.interactable = false;
					else
						Upgrade7.interactable = true;
				}

				if (boughtUpgrade [1, 7] == 5) {
					Upgrade8Text.text = "MAX";
					Upgrade8.interactable = false;
				} else {
					Upgrade8Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 7]];
					upgradePrice8.text = price.ToString ();
					if (playerMoney < price)
						Upgrade8.interactable = false;
					else
						Upgrade8.interactable = true;
				}

				if (boughtUpgrade [1, 8] == 5) {
					Upgrade9Text.text = "MAX";
					Upgrade9.interactable = false;
				} else {
					Upgrade9Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 8]];
					upgradePrice9.text = price.ToString ();
					if (playerMoney < price)
						Upgrade9.interactable = false;
					else
						Upgrade9.interactable = true;
				}

				if (boughtUpgrade [1, 9] == 5) {
					Upgrade10Text.text = "MAX";
					Upgrade10.interactable = false;
				} else {
					Upgrade10Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 9]];
					upgradePrice10.text = price.ToString ();
					if (playerMoney < price)
						Upgrade10.interactable = false;
					else
						Upgrade10.interactable = true;
				}

				if (boughtUpgrade [1, 10] == 5) {
					Upgrade11Text.text = "MAX";
					Upgrade11.interactable = false;
				} else {
					Upgrade11Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [1, 10]];
					upgradePrice11.text = price.ToString ();
					if (playerMoney < price)
						Upgrade11.interactable = false;
					else
						Upgrade11.interactable = true;
				}
			} else {
				if (boughtUpgrade [2, 0] == 5) {
					Upgrade1Text.text = "MAX";
					Upgrade1.interactable = false;
				} else {
					Upgrade1Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 0]];
					upgradePrice1.text = price.ToString ();
					if (playerMoney < price)
						Upgrade1.interactable = false;
					else
						Upgrade1.interactable = true;
				}

				if (boughtUpgrade [2, 1] == 5) {
					Upgrade2Text.text = "MAX";
					Upgrade2.interactable = false;
				} else {
					Upgrade2Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 1]];
					upgradePrice2.text = price.ToString ();
					if (playerMoney < price)
						Upgrade2.interactable = false;
					else
						Upgrade2.interactable = true;
				}

				if (boughtUpgrade [2, 2] == 5) {
					Upgrade3Text.text = "MAX";
					Upgrade3.interactable = false;
				} else {
					Upgrade3Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 2]];
					upgradePrice3.text = price.ToString ();
					if (playerMoney < price)
						Upgrade3.interactable = false;
					else
						Upgrade3.interactable = true;
				}

				if (boughtUpgrade [2, 3] == 5) {
					Upgrade4Text.text = "MAX";
					Upgrade4.interactable = false;
				} else {
					Upgrade4Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 3]];
					upgradePrice4.text = price.ToString ();
					if (playerMoney < price)
						Upgrade4.interactable = false;
					else
						Upgrade4.interactable = true;
				}

				if (boughtUpgrade [2, 4] == 5) {
					Upgrade5Text.text = "MAX";
					Upgrade5.interactable = false;
				} else {
					Upgrade5Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 4]];
					upgradePrice5.text = price.ToString ();
					if (playerMoney < price)
						Upgrade5.interactable = false;
					else
						Upgrade5.interactable = true;
				}

				if (boughtUpgrade [2, 5] == 5) {
					Upgrade6Text.text = "MAX";
					Upgrade6.interactable = false;
				} else {
					Upgrade6Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 5]];
					upgradePrice6.text = price.ToString ();
					if (playerMoney < price)
						Upgrade6.interactable = false;
					else
						Upgrade6.interactable = true;
				}

				if (boughtUpgrade [2, 6] == 5) {
					Upgrade7Text.text = "MAX";
					Upgrade7.interactable = false;
				} else {
					Upgrade7Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 6]];
					upgradePrice7.text = price.ToString ();
					if (playerMoney < price)
						Upgrade7.interactable = false;
					else
						Upgrade7.interactable = true;
				}

				if (boughtUpgrade [2, 7] == 5) {
					Upgrade8Text.text = "MAX";
					Upgrade8.interactable = false;
				} else {
					Upgrade8Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 7]];
					upgradePrice8.text = price.ToString ();
					if (playerMoney < price)
						Upgrade8.interactable = false;
					else
						Upgrade8.interactable = true;
				}

				if (boughtUpgrade [2, 8] == 5) {
					Upgrade9Text.text = "MAX";
					Upgrade9.interactable = false;
				} else {
					Upgrade9Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 8]];
					upgradePrice9.text = price.ToString ();
					if (playerMoney < price)
						Upgrade9.interactable = false;
					else
						Upgrade9.interactable = true;
				}

				if (boughtUpgrade [2, 9] == 5) {
					Upgrade10Text.text = "MAX";
					Upgrade10.interactable = false;
				} else {
					Upgrade10Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 9]];
					upgradePrice10.text = price.ToString ();
					if (playerMoney < price)
						Upgrade10.interactable = false;
					else
						Upgrade10.interactable = true;
				}

				if (boughtUpgrade [2, 10] == 5) {
					Upgrade11Text.text = "MAX";
					Upgrade11.interactable = false;
				} else {
					Upgrade11Text.text = "UPGRADE";
					int price = upgradePrices [boughtUpgrade [2, 10]];
					upgradePrice11.text = price.ToString ();
					if (playerMoney < price)
						Upgrade11.interactable = false;
					else
						Upgrade11.interactable = true;
				}
			}
				
			// [SELECT LEVEL] enable buttons
			if (playerMoney >= 250 || boughtLevel[0] != 0)
				grassLand.interactable = true;
			else
				grassLand.interactable = false;

			if (playerMoney >= 5000 || boughtLevel[1] != 0)
				desertLand.interactable = true;
			else
				desertLand.interactable = false;

			if (playerMoney >= 75000 || boughtLevel[2] != 0)
				winterLand.interactable = true;
			else
				winterLand.interactable = false;

			if (playerMoney >= 250000 || boughtLevel[3] != 0)
				graveLand.interactable = true;
			else
				graveLand.interactable = false;

			if (playerMoney >= 1000000 || boughtLevel[4] != 0)
				sciFiLand.interactable = true;
			else
				sciFiLand.interactable = false;
			// [SELECT VEHICLE] enable buttons
			if (playerMoney >= 250 || boughtVehicle[0] != 0)
				car.interactable = true;
			else
				car.interactable = false;

			if (playerMoney >= 250000 || boughtVehicle[1] != 0)
				orc.interactable = true;
			else
				orc.interactable = false;

			if (playerMoney >= 1000000 || boughtVehicle[2] != 0)
				monster.interactable = true;
			else
				monster.interactable = false;

			// main menu player money print
			money.text = playerMoney.ToString ();
			money2.text = playerMoney.ToString ();
			money3.text = playerMoney.ToString ();
		}
	}
	// [SELECT LEVEL] Button funcitons
	public void ClickLevel1(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtLevel1"))
			info = PlayerPrefs.GetInt ("PlayerBoughtLevel1");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 250;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtLevel1", 1);
			PlayerPrefs.SetInt ("PlayerSelectLevel", 1);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectLevel", 1);
		}
	}

	public void ClickLevel2(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtLevel2"))
			info = PlayerPrefs.GetInt ("PlayerBoughtLevel2");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 5000;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtLevel2", 1);
			PlayerPrefs.SetInt ("PlayerSelectLevel", 2);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectLevel", 2);
		}
	}

	public void ClickLevel3(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtLevel3"))
			info = PlayerPrefs.GetInt ("PlayerBoughtLevel3");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 75000;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtLevel3", 1);
			PlayerPrefs.SetInt ("PlayerSelectLevel", 3);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectLevel", 3);
		}
	}

	public void ClickLevel4(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtLevel4"))
			info = PlayerPrefs.GetInt ("PlayerBoughtLevel4");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 250000;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtLevel4", 1);
			PlayerPrefs.SetInt ("PlayerSelectLevel", 4);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectLevel", 4);
		}
	}

	public void ClickLevel5(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtLevel5"))
			info = PlayerPrefs.GetInt ("PlayerBoughtLevel5");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 1000000;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtLevel5", 1);
			PlayerPrefs.SetInt ("PlayerSelectLevel", 5);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectLevel", 5);
		}
	}
	// [SELECT VEHICLE] Button functions
	public void ClickVehicle1(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtVehicle1"))
			info = PlayerPrefs.GetInt ("PlayerBoughtVehicle1");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 250;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtVehicle1", 1);
			PlayerPrefs.SetInt ("PlayerSelectVehicle", 1);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectVehicle", 1);
		}
	}

	public void ClickVehicle2(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtVehicle2"))
			info = PlayerPrefs.GetInt ("PlayerBoughtVehicle2");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 250000;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtVehicle2", 1);
			PlayerPrefs.SetInt ("PlayerSelectVehicle", 2);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectVehicle", 2);
		}
	}

	public void ClickVehicle3(){
		int info = 0;
		if (PlayerPrefs.HasKey ("PlayerBoughtVehicle3"))
			info = PlayerPrefs.GetInt ("PlayerBoughtVehicle3");
		if (info == 0) {
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= 1000000;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerBoughtVehicle3", 1);
			PlayerPrefs.SetInt ("PlayerSelectVehicle", 3);
		} else {
			PlayerPrefs.SetInt ("PlayerSelectVehicle", 3);
		}
	}

	// [SELECT UPGRADE] button functions

	public void ClickUpgrade1(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 0]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade1", boughtUpgrade [0, 0] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 0]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade1", boughtUpgrade [1, 0] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 0]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade1", boughtUpgrade [2, 0] + 1);
		}
	}

	public void ClickUpgrade2(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 1]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade2", boughtUpgrade [0, 1] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 1]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade2", boughtUpgrade [1, 1] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 1]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade2", boughtUpgrade [2, 1] + 1);
		}
	}

	public void ClickUpgrade3(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 2]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade3", boughtUpgrade [0, 2] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 2]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade3", boughtUpgrade [1, 2] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 2]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade3", boughtUpgrade [2, 2] + 1);
		}
	}

	public void ClickUpgrade4(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 3]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade4", boughtUpgrade [0, 3] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 3]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade4", boughtUpgrade [1, 3] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 3]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade4", boughtUpgrade [2, 3] + 1);
		}
	}

	public void ClickUpgrade5(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 4]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade5", boughtUpgrade [0, 4] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 4]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade5", boughtUpgrade [1, 4] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 4]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade5", boughtUpgrade [2, 4] + 1);
		}
	}

	public void ClickUpgrade6(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 5]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade6", boughtUpgrade [0, 5] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 5]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade6", boughtUpgrade [1, 5] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 5]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade6", boughtUpgrade [2, 5] + 1);
		}
	}

	public void ClickUpgrade7(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 6]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade7", boughtUpgrade [0, 6] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 6]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade7", boughtUpgrade [1, 6] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 6]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade7", boughtUpgrade [2, 6] + 1);
		}
	}

	public void ClickUpgrade8(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 7]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade8", boughtUpgrade [0, 7] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 7]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade8", boughtUpgrade [1, 7] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 7]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade8", boughtUpgrade [2, 7] + 1);
		}
	}

	public void ClickUpgrade9(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 8]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade9", boughtUpgrade [0, 8] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 8]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade9", boughtUpgrade [1, 8] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 8]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade9", boughtUpgrade [2, 8] + 1);
		}
	}

	public void ClickUpgrade10(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 9]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade10", boughtUpgrade [0, 9] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 9]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade10", boughtUpgrade [1, 9] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 9]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade10", boughtUpgrade [2, 9] + 1);
		}
	}

	public void ClickUpgrade11(){
		int vehicleInfo = PlayerPrefs.GetInt ("PlayerSelectVehicle");
		if (vehicleInfo == 1) {
			int price = upgradePrices [boughtUpgrade [0, 10]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle1Upgrade11", boughtUpgrade [0, 10] + 1);
		} else if (vehicleInfo == 2) {
			int price = upgradePrices [boughtUpgrade [1, 10]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle2Upgrade11", boughtUpgrade [1, 10] + 1);
		} else {
			int price = upgradePrices [boughtUpgrade [2, 10]];
			int money = PlayerPrefs.GetInt ("PlayerMoney");
			money -= price;
			PlayerPrefs.SetInt ("PlayerMoney", money);
			PlayerPrefs.SetInt ("PlayerVehicle3Upgrade11", boughtUpgrade [2, 10] + 1);
		}
	}

	// Level load function
	public void LoadLevel(){
		int level = 0;
		if (PlayerPrefs.HasKey ("PlayerSelectLevel"))
			level = PlayerPrefs.GetInt ("PlayerSelectLevel");
		SceneManager.LoadScene (level);
	}

	public void ReloadMain(){
		SceneManager.LoadScene (0);
	}
	// Reset game function
	public void ResetGame(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("PlayerMoney", 500);
	}

	public void ClickSoundOn(){
		PlayerPrefs.SetInt ("PlayerSoundLevel", 0);
	}

	public void ClickSoundOff(){
		PlayerPrefs.SetInt ("PlayerSoundLevel", 5);
	}

	public void ClickSoundAdd(){
		int level = 5;
		if (PlayerPrefs.HasKey ("PlayerSoundLevel")) {
			level = PlayerPrefs.GetInt ("PlayerSoundLevel");
		}
		level++;
		PlayerPrefs.SetInt ("PlayerSoundLevel", level);
	}

	public void ClickSoundMinus(){
		int level = 5;
		if (PlayerPrefs.HasKey ("PlayerSoundLevel")) {
			level = PlayerPrefs.GetInt ("PlayerSoundLevel");
		}
		level--;
		PlayerPrefs.SetInt ("PlayerSoundLevel", level);
	}

	public void ClickMusicOn(){
		PlayerPrefs.SetInt ("PlayerMusicLevel", 0);
	}

	public void ClickMusicOff(){
		PlayerPrefs.SetInt ("PlayerMusicLevel", 5);
	}

	public void ClickMusicAdd(){
		int level = 5;
		if (PlayerPrefs.HasKey ("PlayerMusicLevel")) {
			level = PlayerPrefs.GetInt ("PlayerMusicLevel");
		}
		level++;
		PlayerPrefs.SetInt ("PlayerMusicLevel", level);
	}

	public void ClickMusicMinus(){
		int level = 5;
		if (PlayerPrefs.HasKey ("PlayerMusicLevel")) {
			level = PlayerPrefs.GetInt ("PlayerMusicLevel");
		}
		level--;
		PlayerPrefs.SetInt ("PlayerMusicLevel", level);
	}
	
	void savePlayerScore() {
		string url = "http://t120b166.p1.lt/deirap.php?id=insert&score=" + PlayerPrefs.GetInt ("PlayerScore") + "&name=" + name;
		WWW www = new WWW(url);
		StartCoroutine(SendDataToWebsite(www));
	}

	IEnumerator SendDataToWebsite(WWW www)
	{
		yield return www; 
	}

	IEnumerator WaitForDataFromWebsite(WWW www)
	{
		yield return www;
		Debug.Log (www.text);
		if (www.error == null)
		{
			HighScoreList highScore = JsonUtility.FromJson<HighScoreList> (www.text);
			HighScore.text = 
				"1. " + highScore.pos1.playerScore + " - " + highScore.pos1.playerName + "\n" +
				"2. " + highScore.pos2.playerScore + " - " + highScore.pos2.playerName + "\n" +
				"3. " + highScore.pos3.playerScore + " - " + highScore.pos3.playerName + "\n" +
				"4. " + highScore.pos4.playerScore + " - " + highScore.pos4.playerName + "\n" +
				"5. " + highScore.pos5.playerScore + " - " + highScore.pos5.playerName + "\n" +
				"6. " + highScore.pos6.playerScore + " - " + highScore.pos6.playerName + "\n" +
				"7. " + highScore.pos7.playerScore + " - " + highScore.pos7.playerName + "\n" +
				"8. " + highScore.pos8.playerScore + " - " + highScore.pos8.playerName + "\n" +
				"9. " + highScore.pos9.playerScore + " - " + highScore.pos9.playerName + "\n" +
				"10. " + highScore.pos10.playerScore + " - " + highScore.pos10.playerName + "\n";
		}   
	}

	public void GetPlayerScoreDisplayed() {
		HighScore.text = "Loading...";
		string url = "http://t120b166.p1.lt/deirap.php?id=get";
		WWW www = new WWW(url);
		StartCoroutine(WaitForDataFromWebsite(www));
	}
		
	[Serializable]
	public struct HighScoreList {
		public HighScoreData pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10;
	}
	[Serializable]
	public class HighScoreData {
		public string playerName = "ANONYMOUS";
		public int playerScore = 0;
	}
	
}
