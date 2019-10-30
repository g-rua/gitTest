Shader "Unlit/desolve"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	//ルール画像用のテクスチャを設定可能にする
	_RuleTex("RuleTex",2D) = "white"{}
	//調整スライダー追加
	_Slider("Slider",Range(0,1)) = 1
	}
		SubShader
	{
		//α対応に書き換え
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off
		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
		// make fog work
#pragma multi_compile_fog

#include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f
	{
		float2 uv : TEXCOORD0;
		UNITY_FOG_COORDS(1)
			float4 vertex : SV_POSITION;
	};

	sampler2D _MainTex;
	sampler2D _RuleTex;
	float4 _MainTex_ST;
	float _Slider;

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		UNITY_TRANSFER_FOG(o,o.vertex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		// sample the texture
		fixed4 col = tex2D(_MainTex, i.uv);
	fixed4 alpha = tex2D(_RuleTex, i.uv);
	col.a = step(1 - _Slider, alpha.r);
	// apply fog
	UNITY_APPLY_FOG(i.fogCoord, col);
	return col;
	}
		ENDCG
	}
	}
}
