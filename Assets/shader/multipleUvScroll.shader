Shader "Unlit/multipleUvScroll"
{
	Properties
	{
		_MainTex1("Texture", 2D) = "white" {}
		_MainTex2("Texture", 2D) = "white" {}
		_MainTex3("Texture", 2D) = "white" {}
		_MainTex4("Texture", 2D) = "white" {}
	//X方向に関するパラメータ
		_XSpeed1("XScrollSpeed",Range(-5,5)) = 0
		_YSpeed1("YScrollSpeed",Range(0,5)) = 0

		_XSpeed2("XScrollSpeed",Range(-5,5)) = 0
		_YSpeed2("YScrollSpeed",Range(0,5)) = 0

		_XSpeed3("XScrollSpeed",Range(-5,5)) = 0
		_YSpeed3("YScrollSpeed",Range(0,5)) = 0

		_XSpeed4("XScrollSpeed",Range(-5,5)) = 0
		_YSpeed4("YScrollSpeed",Range(0,5)) = 0
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100
		//透明テクスチャを使用できるようにする
		Blend SrcAlpha OneMinusSrcAlpha
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

	sampler2D _MainTex1;
	sampler2D _MainTex2;
	sampler2D _MainTex3;
	sampler2D _MainTex4;
	float4 _MainTex_ST;
	float _XSpeed1;
	float _YSpeed1;

	float _XSpeed2;
	float _YSpeed2;

	float _XSpeed3;
	float _YSpeed3;

	float _XSpeed4;
	float _YSpeed4;
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

		i.uv.x += _XSpeed * _Time;
	i.uv.y += _YSpeed * _Time;
	// sample the texture
	fixed4 col = tex2D(_MainTex, i.uv);
	fixed4 col = tex2D(_MainTex, i.uv);
	fixed4 col = tex2D(_MainTex, i.uv);
	fixed4 col = tex2D(_MainTex, i.uv);
	// apply fog
	UNITY_APPLY_FOG(i.fogCoord, col);
	return col;
	}
		ENDCG
	}
	}
}
