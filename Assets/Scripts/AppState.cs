using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AppState
{

	public enum ANIMATIONSTATES 
	{
		IDLEtoINTRO = 0,
		INTROtoL1_1 = 1,
		L1_1toL1_2 = 2,
		L1_2toL1_3 = 3,
		L1_3toL1_4 = 4,
		L1_4toL2_1 = 5,
		L2_1toL2_2 = 6,
		L2_2toL2_3 = 7,
		L2_3toL2_4 = 8,
		L2_4toL3_1 = 9,
		L3_1toL3_2 = 10,
		L3_2toL3_3 = 11,
		L3_3toL3_4 = 12,
		L3_4toL4_1 = 13,
		L4_1toL4_2 = 14,
		L4_2toL4_3 = 15,
		L4_3toL4_4 = 16,
		L4_4toOUTRO = 17

	}

	public enum PRODUCTS
	{
		PRODUCT1 = 0,
		PRODUCT2 = 1,
		PRODUCT3 = 2
	}

	public enum APPSTATES
	{
		MODEL1 = 0,
		MODEL2 = 1,
		MODEL3 = 2,
		MODEL4 = 4
	};

	// all canvas states that update each panel on next/prev items
	public enum CANVASSTATES
	{
		NONE = 0,
		SCANMARKER = 1,
		FOUNDMARKER = 2,
		SCENECONTROLS = 3,
		PROGRESSSLIDEINFO = 4,
		EXPLORE_CHARACTERS = 5,
		TAPANDHIGHLIGHT = 6,
		REAGAN = 7,
		TAPANDROTATE = 8,
		BRADLEY = 9,
		HICKLEY = 10,
		SCENE1_REAGAN_WALKS_OUT = 11,
		SCENE1_FREEZE_FRAME_HINKLEY = 12,
		SCENE2_SHOTS_FIRED_1 = 13,
		SCENE2_SHOTS_FIRED_2 = 14,
		SCENE2_SHOTS_FIRED_3 = 15,
		SCENE2_SHOTS_FIRED_4 = 16,
		SCENE2_SHOTS_FIRED_5 = 17,
		SCENE2_SHOTS_FIRED_6 = 18,
		SCENE2_SHOTS_FIRED_7 = 19,
		SCENE4_REAGANFOLLOWUP = 20,
		SCENE3_AFTERMATH_1 = 21,
		SCENE3_AFTERMATH_2 = 22,
		SCENE3_AFTERMATH_3 = 23,
		SCENE3_AFTERMATH_4 = 24,
		SCENE3_AFTERMATH_5 = 25,
		SCENE5_FOLLOWUP_1 = 26,
		SCENE5_FOLLOWUP_2 = 27,
		SCENE5_FOLLOWUP_3 = 28,
		APP_END_SCREEN = 29
	};



	public static Dictionary<CANVASSTATES, string> AnimationGuide = new Dictionary<CANVASSTATES, string> () {
		{ CANVASSTATES.SCENE1_REAGAN_WALKS_OUT, "KR_S1_Anim_V1(Clone)" }
	};

	public static Vector3 defaultlocation = new Vector3(200,0,0);

	public static Dictionary<CANVASSTATES,string> AudioGuide = new Dictionary<CANVASSTATES,string>() {
		{ CANVASSTATES.SCENE1_REAGAN_WALKS_OUT, "KR_Reagan Walks Out" },
		{ CANVASSTATES.SCENE2_SHOTS_FIRED_1, "KR_Shots Fired"},
		{ CANVASSTATES.SCENE3_AFTERMATH_1, "KR_Aftermath"}
	};

	public static Dictionary<CANVASSTATES,string> AnimationStateGuide = new Dictionary<CANVASSTATES,string> () {
		{ CANVASSTATES.SCENE1_REAGAN_WALKS_OUT, "S1_Anim_IDLEtoState"},
		{ CANVASSTATES.SCENE2_SHOTS_FIRED_1, "S2_Anim1_IDLEtoBullet1"},
		{ CANVASSTATES.SCENE2_SHOTS_FIRED_2, "S2_Anim1_IDLEtoBullet2"},
		{ CANVASSTATES.SCENE2_SHOTS_FIRED_3, "S2_Anim1_IDLEtoBullet3"},
		{ CANVASSTATES.SCENE2_SHOTS_FIRED_4, "S2_Anim1_IDLEtoBullet4"},
		{ CANVASSTATES.SCENE2_SHOTS_FIRED_5, "S2_Anim1_IDLEtoBullet5"},
		{ CANVASSTATES.SCENE2_SHOTS_FIRED_6, "S2_Anim1_IDLEtoBullet6"},
		{ CANVASSTATES.SCENE3_AFTERMATH_4, "S4_Anim_IDLEtoState"},
		{ CANVASSTATES.SCENE4_REAGANFOLLOWUP, "S3_IDLEtoACTION"}
	};

	public static Dictionary<PRODUCTS,XadPath> ProductAddress = new Dictionary<PRODUCTS,XadPath> () {
		{ PRODUCTS.PRODUCT1, new XadPath("537 W 27th St New York, NY","37 North Moore Street, New York, NY 10013 ") },
		{ PRODUCTS.PRODUCT2, new XadPath("537 W 27th St New York, NY","1 East 1st St, NYC 10003") },
		{ PRODUCTS.PRODUCT3, new XadPath("537 W 27th St New York, NY","361 Stagg st, Brooklyn, NY") }
	};



}
