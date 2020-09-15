using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PMx
{
    //-------------------------------------------------------------------------
    // Title   : 生産管理システムに関するデータ構造を格納するクラス
    // Date    : 2020/ 4/21
    // Author  : 金子　淳哉
    // History :
    //-------------------------------------------------------------------------
    /// <summary>
    /// 生産管理システムに関するデータ構造を格納するクラス
    /// </summary>
    public class zPMxData
    {
        //---------------------------------------------------------------------
        // Title   : 列挙型 格納クラス
        // Date    : 2020/ 4/17
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 列挙型 格納クラス
        /// </summary>
        public class enm
        {
            //-----------------------------------------------------------------
            // Title   : 鋼材組み合わせ
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 鋼材組み合わせ
            /// </summary>
            public enum Pair
            {
                /// <summary>
                /// 1本（[）
                /// </summary>
                Single = 0,

                /// <summary>
                /// 背合わせ2本（][）
                /// </summary>
                BackToBack = 1,

                /// <summary>
                /// 腹合わせ2本（[]）
                /// </summary>
                FrontToFront = 2,

                /// <summary>
                /// 同方向2本（[[）
                /// </summary>
                FrontToBack = 3,

                /// <summary>
                /// 上下2本（+,CTを上下でフランジ部分を合わせる入力）
                /// </summary>
                UpDown = 4,
            }

            //-----------------------------------------------------------------
            // Title   : ３Ｄデータ構造種類
            // History : 2020/ 4/20 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// ３Ｄデータ構造種類
            /// </summary>
            public enum CoordKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// ストレート
                /// </summary>
                Straight = 1,

                /// <summary>
                /// アーチ
                /// </summary>
                Arch = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 部材向き
            // History : 2020/ 4/20 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 部材向き
            /// </summary>
            public enum Set
            {
                /// <summary> ┓</summary>
                VUL = 131,

                /// <summary> ┏</summary>
                VUR = 132,

                /// <summary> ┛</summary>
                VDL = 141,

                /// <summary> ┗</summary>
                VDR = 142,

                /// <summary>┗━</summary>
                HLU = 213,

                /// <summary>┏━</summary>
                HLD = 214,

                /// <summary> ━┛</summary>
                HRU = 223,

                /// <summary> ━┓</summary>
                HRD = 224,
            }

            //-----------------------------------------------------------------
            // Title   : 通りタイプ
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 通りタイプ
            /// </summary>
            public enum StreetType
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 本通り
                /// </summary>
                Real = 1,

                /// <summary>
                /// 仮通り
                /// </summary>
                Dummy = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 通りラインスタイル
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 通りラインスタイル
            /// </summary>
            public enum StreetLineStyle
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 直線
                /// </summary>
                Line = 1,

                /// <summary>
                /// 円弧
                /// </summary>
                Arc = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 階タイプ
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 階タイプ
            /// </summary>
            public enum FloorType
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 本階
                /// </summary>
                Real = 1,

                /// <summary>
                /// 仮階
                /// </summary>
                Dummy = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 部材タイプを定義する列挙体
            // History : 2020/ 3/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 部材タイプを定義する列挙体
            /// </summary>
            public enum BuzaiType
            {
                /// <summary>
                /// 鋼材
                /// </summary>
                [attEnumLabel("鋼材")]
                Material = 0,

                /// <summary>
                /// コア
                /// </summary>
                [attEnumLabel("コア")]
                Core = 1,

                /// <summary>
                /// 二次部材
                /// </summary>
                [attEnumLabel("二次部材")]
                SecMaterial = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 部品種類
            // History : 2020/ 4/30 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 部品種類
            /// </summary>
            public enum BuhinKind
            {
                /// <summary>
                /// 通常
                /// </summary>
                Normal = 0,

                /// <summary>
                /// その他既製品
                /// </summary>
                Ready = 1,
            }

            //-----------------------------------------------------------------
            // Title   : 入力面種類
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 入力面種類
            /// </summary>
            public enum InpFace
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 平面入力
                /// </summary>
                Framing = 1,

                /// <summary>
                /// 側面入力
                /// </summary>
                Elevation = 2,

                /// <summary>
                /// 母屋配置面入力
                /// </summary>
                RoofFace = 3,

                /// <summary>
                /// 胴縁配置面入力
                /// </summary>
                WallFace = 4,
            }

            //-----------------------------------------------------------------
            // Title   : 要素種類（形鋼・板）を定義する列挙体
            // History : 2020/ 3/ 5 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 要素種類（形鋼・板）を定義する列挙体
            /// </summary>
            public enum ElementKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 形鋼
                /// </summary>
                Material = 1,

                /// <summary>
                /// 板
                /// </summary>
                Plate = 2,
            }

            //-----------------------------------------------------------------
            // Title   : ３Ｄ板データ種類
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// ３Ｄ板データ種類
            /// </summary>
            /// <remarks>
            /// zLNSFDLiner.enm.PlateKind
            /// </remarks>
            public enum PlateKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>仕口 トップダイアフラム</summary>
                Core_TopDia = 1,

                /// <summary>仕口 通しダイアフラム</summary>
                Core_TDia = 2,

                /// <summary>仕口 内ダイアフラム</summary>
                Core_IDia = 3,

                /// <summary>仕口 既製品仕口の最上部鋼板</summary>
                Core_ReadyMadeTopPL = 53,

                /// <summary>仕口 パネル</summary>
                Core_Panel = 4,

                /// <summary>仕口 水平パネル</summary>
                Core_PanelH = 5,

                /// <summary>仕口 垂直パネル（※SF Liner2では「縦スチフナ」）</summary>
                Core_PanelV = 6,


                /// <summary>ガセット</summary>
                Gusset = 7,

                /// <summary>ガセット先端プレート</summary>
                Gusset_Base = 76,

                /// <summary>スチフナ</summary>
                Stiffener = 8,

                /// <summary>ベース</summary>
                Base = 9,

                /// <summary>ベース 補強板</summary>
                Base_SupPL = 10,

                /// <summary>ベース リブ</summary>
                Base_Rib = 11,

                //スプライス板のフランジについて(側面から見た図)
                //右端部の梁成がでかい場合
                //                    ┌──────────────────┐
                //                    │                 12                 │
                //                    └──────────────────┘
                //                    ┌────────┐┌────────────────
                //                    │      18        │├────────────────
                //                    └────────┘┌────────┐
                //───────────────────┐│      21        │
                //───────────────────┤└────────┘
                //                    ┌──────────────────┐
                //                    │                 13                 │
                //                    └──────────────────┘
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                    ┌──────────────────┐
                //                    │                 15                 │
                //                    └──────────────────┘
                //───────────────────┤┌────────┐
                //───────────────────┘│      25        │
                //                    ┌────────┐└────────┘
                //                    │       22       │├────────────────
                //                    └────────┘└────────────────
                //                    ┌──────────────────┐
                //                    │                 14                 │
                //                    └──────────────────┘

                //左端部の梁成がでかい場合
                //                    ┌──────────────────┐
                //                    │                 12                 │
                //                    └──────────────────┘
                //───────────────────┐┌────────┐
                //───────────────────┤│      20        │
                //                    ┌────────┐└────────┘
                //                    │       19       │┌────────────────
                //                    └────────┘├────────────────
                //                    ┌──────────────────┐
                //                    │                 13                 │
                //                    └──────────────────┘
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                    ┌──────────────────┐
                //                    │                 15                 │
                //                    └──────────────────┘
                //                    ┌────────┐├────────────────
                //                    │       23       │└────────────────
                //                    └────────┘┌────────┐
                //───────────────────┤│       24       │
                //───────────────────┘└────────┘
                //                    ┌──────────────────┐
                //                    │                 14                 │
                //                    └──────────────────┘

                //スプライス板のウェブについて(平面から見た図)
                //右端部の梁ウェブ厚がでかい場合
                //───────────────────┐┌────────────────
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                    ┌──────────────────┐
                //                    │                 17                 │
                //                    └──────────────────┘
                //                    ┌────────┐├────────────────
                //                    │      27        ││
                //                    └────────┘│
                //───────────────────┤│
                //───────────────────┤│
                //                    ┌────────┐│
                //                    │      26        ││
                //                    └────────┘├────────────────
                //                    ┌──────────────────┐
                //                    │                 16                 │
                //                    └──────────────────┘
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //───────────────────┘└────────────────

                //左端部の梁ウェブ厚がでかい場合
                //───────────────────┐┌────────────────
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //                    ┌──────────────────┐
                //                    │                 17                 │
                //                    └──────────────────┘
                //───────────────────┤┌────────┐
                //                                      ││      29        │
                //                                      │└────────┘
                //                                      │├────────────────
                //                                      │├────────────────
                //                                      │┌────────┐
                //                                      ││      28        │
                //───────────────────┤└────────┘
                //                    ┌──────────────────┐
                //                    │                 16                 │
                //                    └──────────────────┘
                //                                      ││
                //                                      ││
                //                                      ││
                //                                      ││
                //───────────────────┘└────────────────


                /// <summary>スプライス フランジ表(上)</summary>
                Splice_FlgRight_Up = 12,

                /// <summary>スプライス フランジ裏(上)</summary>
                Splice_FlgBack_Up = 13,

                /// <summary>スプライス フランジ表(下)</summary>
                Splice_FlgRight_Down = 14,

                /// <summary>スプライス フランジ裏(下)</summary>
                Splice_FlgBack_Down = 15,

                /// <summary>スプライス ウェブ(手前)</summary>
                Splice_Web_Front = 16,

                /// <summary>スプライス ウェブ(奥)</summary>
                Splice_Web_Back = 17,

                /// <summary>スプライス フランジフィラー表(左側上)</summary>
                Splice_FlgFillerRight_L_Up = 18,

                /// <summary>スプライス フランジフィラー裏(左側上)</summary>
                Splice_FlgFillerBack_L_Up = 19,

                /// <summary>スプライス フランジフィラー表(右側上)</summary>
                Splice_FlgFillerRight_R_Up = 20,

                /// <summary>スプライス フランジフィラー裏(右側上)</summary>
                Splice_FlgFillerBack_R_Up = 21,

                /// <summary>スプライス フランジフィラー表(左側下)</summary>
                Splice_FlgFillerRight_L_Down = 22,

                /// <summary>スプライス フランジフィラー裏(左側下)</summary>
                Splice_FlgFillerBack_L_Down = 23,

                /// <summary>スプライス フランジフィラー表(右側下)</summary>
                Splice_FlgFillerRight_R_Down = 24,

                /// <summary>スプライス フランジフィラー裏(右側下)</summary>
                Splice_FlgFillerBack_R_Down = 25,

                /// <summary>スプライス ウェブフィラー(左側手前)</summary>
                Splice_WebFiller_L_Front = 26,

                /// <summary>スプライス ウェブフィラー(左側奥)</summary>
                Splice_WebFiller_L_Back = 27,

                /// <summary>スプライス ウェブフィラー(右側手前)</summary>
                Splice_WebFiller_R_Front = 28,

                /// <summary>スプライス ウェブフィラー(右側奥)</summary>
                Splice_WebFiller_R_Back = 29,

                /// <summary>エレクション ピース(上板)</summary>
                Erection_Piece_Up = 30,

                /// <summary>エレクション ピース(下板)</summary>
                Erection_Piece_Down = 31,

                /// <summary>エレクション ピース(スプライス)</summary>
                Erection_Piece_Splice = 32,

                /// <summary>セットバックプレート</summary>
                SetbackPL = 33,

                /// <summary>合掌プレート</summary>
                JointPL = 34,

                /// <summary>ブレース シート</summary>
                Brace_Sheet = 35,

                /// <summary>端部鋼材板1</summary>
                MaterialEdgePL_1 = 36,

                /// <summary>端部鋼材板2</summary>
                MaterialEdgePL_2 = 37,

                /// <summary>端部キャップ</summary>
                MaterialEdgeCap = 52,

                /// <summary>スチフナ(自動)</summary>
                StiffenerAuto = 38,

                /// <summary>組合せフィラー</summary>
                PairFiller = 39,

                /// <summary>シート+WEBスプライス 割り込み板(左上)</summary>
                BrcSplSheet_Plate_L_Up = 40,

                /// <summary>シート+WEBスプライス 割り込み板(右上)</summary>
                BrcSplSheet_Plate_R_Up = 41,

                /// <summary>シート+WEBスプライス 割り込み板(左下)</summary>
                BrcSplSheet_Plate_L_Down = 42,

                /// <summary>シート+WEBスプライス 割り込み板(右下)</summary>
                BrcSplSheet_Plate_R_Down = 43,

                /// <summary>十字継手 通し板(左)</summary>
                BrcCrossPLT_Plate_L = 44,

                /// <summary>十字継手 通し板(右)</summary>
                BrcCrossPLT_Plate_R = 45,

                /// <summary>エレクション トッププレート(上板)</summary>
                Erection_TopPL_Up = 46,

                /// <summary>エレクション トッププレート(下板)</summary>
                Erection_TopPL_Down = 47,

                /// <summary>エレクション 通しプレート（上）</summary>
                /// <remarks>
                ///         │  上  │           │  上  │
                ///         │ConRG │           │ConRG │
                ///         │      │           │      │
                ///         │      │       ┌─┴───┴─┐
                ///         └───┘       └━━━━━━━┘
                ///     ┌━━━━━━━┐       ┌───┐        ┌───────┐
                ///     └─┬───┬─┘       │      │        │━━━━━━━│
                ///         │      │           │      │        └─┬───┬─┘
                ///         │ConLF │           │ConLF │            │ConLF │
                ///         │  下  │           │  下  │            │  下  │
                ///  
                /// ※━━太線が板の基準平面になるものとする。        
                /// </remarks>
                Erection_ThroughPL_Up = 93,

                /// <summary>エレクション 通しプレート（下）</summary>
                Erection_ThroughPL_Down = 94,

                /// <summary>エレクション 治具落下防止用バー</summary>
                Erection_JigSafetyBar = 75,


                /// <summary>管継手ベース（上）</summary>
                /// <remarks>
                ///         │  上  │
                ///       ┌┤ConRG ├┐
                ///       ││      ││
                ///     ┌┴┴───┴┴┐  
                ///     └───────┘
                ///     ┌───────┐
                ///     └┬┬───┬┬┘
                ///       ││      ││
                ///       └┤ConLF ├┘
                ///         │  下  │
                /// </remarks>
                Pipe_Base_Up = 65,

                /// <summary>管継手ベース（下）</summary>
                Pipe_Base_Down = 66,

                /// <summary>管継手ベース リブ（上）</summary>
                Pipe_BaseRib_Up = 67,

                /// <summary>管継手ベース リブ（下）</summary>
                Pipe_BaseRib_Down = 68,


                /// <summary>
                /// ワッシャー
                /// <para>※ボルト接合で生成されるワッシャー</para>
                /// </summary>
                Washer = 48,

                /// <summary>
                /// フィラー
                /// <para>※ボルト接合で生成される挟み板</para>
                /// </summary>
                Filler = 49,

                /// <summary>リブ・スチフナー リブ</summary>
                RibStiffener_Rib = 50,

                /// <summary>リブ・スチフナー スチフナー</summary>
                RibStiffener_Stiffener = 51,

                /// <summary>ハンチ補強板 リブ</summary>
                HanceRib_Rib = 55,

                /// <summary>ハンチ補強板 スチフナー</summary>
                HanceRib_Stiffener = 56,


                /// <summary>塞ぎプレート 外</summary>
                BlindPL_Out = 57,

                /// <summary>塞ぎプレート 内</summary>
                BlindPL_In = 58,


                /// <summary>コーナーピース</summary>
                PieceCorner = 60,

                /// <summary>接続ピース</summary>
                PieceConnect = 61,

                /// <summary>支持ピース</summary>
                PieceSupport = 62,

                /// <summary>ピース リブ</summary>
                Piece_Rib = 63,


                /// <summary>先端プレート</summary>
                EdgePlate = 70,

                /// <summary>腹側フィラー</summary>
                RipFiller = 71,

                /// <summary>サイドプレート</summary>
                SidePL = 72,

                /// <summary>付けフランジ（子部材 上フランジ用）</summary>
                ConnectFLG_Up = 73,

                /// <summary>付けフランジ（子部材 下フランジ用）</summary>
                ConnectFLG_Dn = 74,


                /// <summary>継手一体化 合掌PLとガセットの一体化</summary>
                JointCombo_JointPLGst = 80,

                /// <summary>継手一体化 亀の甲</summary>
                JointCombo_BraceKm = 81,

                /// <summary>継手一体化 ブレースシート一体化</summary>
                JointCombo_BraceSheet = 82,

                /// <summary>継手一体化 ガセットとブレースシートの一体化</summary>
                JointCombo_Gst_BraceSheet = 83,

                /// <summary>継手一体化 方杖ガセット一体化</summary>
                JointCombo_StrutGusset = 84,

                /// <summary>継手一体化 振れ止めガセット一体化</summary>
                JointCombo_SteadyGusset = 85,


                /// <summary>部材溶接 ウェブ補強板</summary>
                MatWeldPL_Web = 90,

                /// <summary>部材溶接 ブレースシートリブ</summary>
                MatWeldPL_BraceSheetRib = 91,

                /// <summary>部材溶接 ブレース三角リブ</summary>
                MatWeldPL_BraceTriangleRib = 92,


                /// <summary>部材 上フランジ板</summary>
                Material_FlgUp = 100,

                /// <summary>部材 下フランジ板</summary>
                Material_FlgDn = 101,

                /// <summary>部材 ウェブ板</summary>
                Material_Web = 102,

                /// <summary>部材 三角プレート展開 ウェブ</summary>
                Material_SpreadTrianglePL_Web = 105,

                /// <summary>部材 プレート２枚展開 上フランジ</summary>
                Material_SpreadDoublePL_FlgUp = 120,

                /// <summary>部材 プレート２枚展開 下フランジ</summary>
                Material_SpreadDoublePL_FlgDn = 121,

                /// <summary>部材 プレート２枚展開 ウェブ</summary>
                Material_SpreadDoublePL_Web = 122,

                // コラム、B.Box用（'2015/03/26 - 升本 吉昭）
                //  <縦使い>                       <横使い>
                //     LU   BoxUp   RU               LU   BoxRg   RU
                //      ┏━━━━━┓                 ┏┳━━━┳┓
                //      ┣┳━━━┳┫                 ┃┣━━━┫┃
                //      ┃┃      ┃┃                 ┃┃     ┃┃
                // BoxLf┃┃      ┃┃BoxRg       BoxUp┃┃     ┃┃BoxDn
                //      ┃┃      ┃┃                 ┃┃     ┃┃
                //      ┣┻━━━┻┫                 ┃┣━━━┫┃
                //      ┗━━━━━┛                 ┗┻━━━┻┛
                //     LD   BoxDn   RD               LD   BoxLf   RD
                /// <summary>部材 上通し板</summary>
                Material_BoxUp = 130,

                /// <summary>部材 下通し板</summary>
                Material_BoxDn = 131,

                /// <summary>部材 左繋ぎ板</summary>
                Material_BoxLf = 132,

                /// <summary>部材 右繋ぎ板</summary>
                Material_BoxRg = 133,


                /// <summary>二次部材 スリーブ補強板</summary>
                SecSleeve_SupPL = 170,

                /// <summary>二次部材 デッキ受け</summary>
                SecDeckSupPL = 171,

                /// <summary>二次部材 特殊部品構成板</summary>
                SecPartsEx = 172,

                /// <summary>二次部材 SRCバンド</summary>
                SecSRCBand = 173,

                /// <summary>二次部材 水切りプレート</summary>
                SecWeatherboard = 174,


                /// <summary>既製品ベース</summary>
                ReadyBase = 200,

                /// <summary>既製品ブレース シート</summary>
                ReadyBraceSheet = 201,

                /// <summary>既製品スリーブ</summary>
                ReadySleeve = 202,

                /// <summary>既製品スリーブ ハイリングSPスティック</summary>
                ReadySleeve_HRSPStick = 204,

                /// <summary>既製品通しダイア</summary>
                ReadyCoreTDia = 203,

                /// <summary>既製品コラムカプラ（上）</summary>
                /// <remarks>
                ///         │  上  │
                ///         │ConRG │
                ///         │      │
                ///       ┌┴───┴┐  
                ///       └─────┘
                ///       ┌─────┐
                ///       └┬───┬┘
                ///         │      │
                ///         │ConLF │
                ///         │  下  │
                /// </remarks>
                ReadyColumnCoupler_Up = 205,

                /// <summary>既製品コラムカプラ（下）</summary>
                ReadyColumnCoupler_Down = 206,



                // 住金システム建築 用
                //-----------------------------------------------------------------------------
                // ※住金システム建築 柱BOX型柱脚支承板仕様
                //    │:          :│
                //    │:    柱    :│            ┌──────┐
                //    │:          :│            │    ┌リブ通しPL 
                //  ┌────────台座PL      │    ││    │
                //  └┬──┬┬──┬┘          │┌─┤├─┐│
                //     ＼   ││   ／             │└─┤├─リブPL
                //       ＼ ││ ／               │    ││    │
                //      ┌┴┴┴┴┐              │    └┘    │
                //      └────上部B.PL        └──────┘
                //
                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 台座PL</summary>
                zSumikin_QFU_PedestalPL = 1001,

                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 上部B.PL</summary>
                zSumikin_QFU_UpBasePL = 1002,

                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 リブ通しPL</summary>
                zSumikin_QFU_RibTPL = 1003,

                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 リブPL</summary>
                zSumikin_QFU_RibPL = 1004,

                // ※住金システム建築 継手
                //                                              ┌┐        ┏フランジPL
                //                                              ││        ┃┃│
                //                                              ││        ┗┛│
                //                                              │└─────┘│
                //                                              ウェブPL━━┓┐│
                //                                              ││┣━━━╋┓│
                //  ┌──────────スプリットプレート    ││┃      ┃┃│
                //  └┬────┬────┘                    └┘┗リブPL┻┛┘
                //    │        │=========フィラープレート
                //    │        │┌──────────        ││          ││
                //    │        ││￣￣￣￣￣￣￣￣￣￣        ││          │┌┐
                //    │        ││                            │ウェブPL━┳┓││
                //    │        ││                            ││┃      ┃┃││
                //    │        ││                            ││┣━━━┫┃│└─────┐
                //    │        ││＿＿＿＿＿＿＿＿＿＿        │リブPL━━┫┃│┌─────スプリットティ
                //  ┌┴────┴└───┬──────        ││┃      ┃┃││
                //  └┬────┬────スプリットプレート    ││┗━━━┻┛││
                //    │        │                              ││          │└┘
                //    │        │                              ││          ││
                /// <summary>住金システム建築 継手 スプリットプレート</summary>
                zSumikin_Joint_SplitPL = 1011,

                /// <summary>住金システム建築 継手 フィラープレート</summary>
                zSumikin_Joint_Filler = 1012,

                /// <summary>住金システム建築 継手 スプリットティ フランジPL</summary>
                zSumikin_Joint_SplitT_FLGPL = 1013,

                /// <summary>住金システム建築 継手 スプリットティ ウェブPL</summary>
                zSumikin_Joint_SplitT_WEBPL = 1014,

                /// <summary>住金システム建築 継手 スプリットティ リブPL</summary>
                zSumikin_Joint_SplitT_RibPL = 1015,

                // ※住金システム建築 母屋ピース
                //          ┌───┐
                //          │  ○  │
                //  ┌───┘      │
                //  │  ○      ○  │
                //  │             ／
                //  │           ／
                //  │  ○     ／
                //  └────
                /// <summary>住金システム建築 母屋ピース YKピース</summary>
                zSumikin_RoofPiece_YKPiece = 1020,

                // ※住金システム建築 Tio柱脚 TK金物
                //  │|                          |│
                //  │|                          |│
                //  │|                          |│
                //  │| ┌TK金物───────┐ |│ ┌┐
                //  │| │  ┏┓  ┏┓  ┏リブPL |│ │┏━リブPL
                //  │| │○┃┃○┃┃○┃┃○│ |│ │┃   ＼
                //  │| │  ┃┃  ┃┃  ┃┃  │ |│ │┃     ＼
                //  │| │○┃┃  ┃┃  ┃┃○│ |│ │┃      ┃
                //  └─│＿┗┛＿┗┛＿┗┛＿│─┘ │┗━━━┛┐
                //      └──────────┘     └─────┘
                //
                /// <summary>住金システム建築 Tio柱脚 TK金物 リブPL</summary>
                zSumikin_TioTK_RibPL = 1030,

                // ※住金システム建築 スプライス
                //
                //            ┏━━━━━━━━━━リブPL（上）
                //            ┃                    ┃
                //          ┌┗━━━━━━━━━━┛┐
                //  ────└────────────┘────
                //  ￣￣￣￣￣￣￣￣￣￣││￣￣￣￣￣￣￣￣￣￣
                //                      ││
                //                      ││
                //                      ││
                //  ＿＿＿＿＿＿＿＿＿＿││＿＿＿＿＿＿＿＿＿＿
                //  ────┌────────────┐────
                //          └┏━━━━━━━━━━┓┘
                //            ┃                    ┃
                //            ┗━━━━━━━━━━リブPL（下）
                //
                /// <summary>住金システム建築 スプライス リブPL（上）</summary>
                zSumikin_Splice_RibPLU = 1040,

                /// <summary>住金システム建築 スプライス リブPL（下）</summary>
                zSumikin_Splice_RibPLD = 1041,
                //-----------------------------------------------------------------------------
            }

            //-----------------------------------------------------------------
            // Title   : 切り欠き種類を定義する列挙体
            // History : 2020/ 3/ 6 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 切り欠き種類を定義する列挙体
            /// </summary>
            public enum NotchKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                [attEnumLabel("")]
                Undefined = 0,

                /// <summary>
                /// ガセット下端処理によるフランジ切欠き
                /// </summary>
                [attEnumLabel("ガセット下端処理によるフランジ切欠き")]
                FlgCut_Gusset = 1,

                /// <summary>
                /// 支持ガセットによる切欠き
                /// </summary>
                [attEnumLabel("支持ガセットによる切欠き")]
                FlgCut_GussetSup = 2,

                /// <summary>
                /// ウェブ端部切欠き
                /// </summary>
                [attEnumLabel("ウェブ端部切欠き")]
                WebCut_EdgeShape = 2,

                /// <summary>
                /// ガセット下端処理によるウェブ切欠き
                /// </summary>
                [attEnumLabel("ガセット下端処理によるウェブ切欠き")]
                WebCut_Gusset = 4,

                /// <summary>
                /// その他
                /// </summary>
                [attEnumLabel("その他")]
                Other = 255,
            }

            //-----------------------------------------------------------------
            // Title   : ２Ｄ図形データ種類
            // History : 2020/ 4/20 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// ２Ｄ図形データ種類
            /// </summary>
            public enum Figure2DKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 円
                /// </summary>
                Circle = 1,

                /// <summary>
                /// 楕円
                /// </summary>
                Ellipse = 2,

                /// <summary>
                /// 線分
                /// </summary>
                Line = 10,

                /// <summary>
                /// 円弧
                /// </summary>
                Arc = 11,

                /// <summary>
                /// 楕円弧
                /// </summary>
                EllipseArc = 12,
            }

            //-----------------------------------------------------------------
            // Title   : 部材データの展開情報
            // History : 2020/ 4/20 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 部材データの展開情報
            /// </summary>
            public enum MaterialSpread
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 展開なし
                /// </summary>
                None = 1,

                /// <summary>
                /// 全てプレート展開
                /// </summary>
                AllPL = 2,

                /// <summary>
                /// 鋼材＋三角プレート展開
                /// </summary>
                Mat_TrianglePL = 3,

                /// <summary>
                /// 鋼材＋プレート２枚展開
                /// </summary>
                Mat_DoublePL = 4,
            }

            //-----------------------------------------------------------------
            // Title   : 端部タイプ列挙体
            // History : 2020/ 3/ 4 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 端部タイプ
            /// </summary>
            public enum EdgeType
            {
                /// <summary>
                /// なし
                /// </summary>
                [attEnumLabel("")]
                None = 0,

                /// <summary>
                /// 継手
                /// </summary>
                [attEnumLabel("継手")]
                Joint = 1,

                /// <summary>
                /// 溶接
                /// </summary>
                [attEnumLabel("溶接")]
                Weld = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 端部接続先種類
            // History : 2020/ 6/24 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 端部接続先種類
            /// </summary>
            public enum EdgeConnectKind
            {
                /// <summary>
                /// 接続なし
                /// </summary>
                /// <remarks>
                /// 通りや補助線などへの接続も
                /// </remarks>
                None,

                /// <summary>
                /// 鋼材接続
                /// </summary>
                Buzai,

                /// <summary>
                /// 仕口 Ｉ接続
                /// </summary>
                ShiguchiI,

                /// <summary>
                /// 仕口 Ｔ接続
                /// </summary>
                ShiguchiT,

                /// <summary>
                /// 仕口 梁貫通接続
                /// </summary>
                ShiguchiThrough,
            }

            //-----------------------------------------------------------------
            // Title   : 穴種類を定義する列挙体
            // History : 2020/ 3/ 4 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 穴種類を定義する列挙体
            /// </summary>
            public enum HoleKind
            {
                /// <summary>
                /// 通常の穴
                /// </summary>
                [attEnumLabel("通常穴")]
                Normal = 0,

                /// <summary>
                /// ボルト穴
                /// </summary>
                [attEnumLabel("ボルト穴")]
                Bolt = 1,

                /// <summary>
                /// アンカーボルト穴
                /// </summary>
                [attEnumLabel("アンカーボルト穴")]
                AnchorBolt = 2,

                /// <summary>
                /// スリーブ穴
                /// </summary>
                [attEnumLabel("スリーブ穴")]
                Sleeve = 3,
            }

            //-----------------------------------------------------------------
            // Title   : 穴形状
            // History : 2020/ 4/21 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 穴形状
            /// </summary>
            public enum HoleShape
            {
                /// <summary>
                /// 円
                /// </summary>
                [attEnumLabel("円")]
                Circle = 0,

                /// <summary>
                /// 長円
                /// </summary>
                [attEnumLabel("長円")]
                Oval = 1,

                /// <summary>
                /// 楕円
                /// </summary>
                [attEnumLabel("楕円")]
                Ellipse = 2,

                /// <summary>
                /// 四角
                /// </summary>
                [attEnumLabel("四角")]
                Rectangle = 3,
            }

            //-----------------------------------------------------------------
            // Title   : スリーブ種類
            // History : 2020/ 4/21 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// スリーブ種類
            /// </summary>
            public enum SleeveKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                [attEnumLabel("")]
                Undefined = 0,

                /// <summary>
                /// スリーブ
                /// </summary>
                [attEnumLabel("スリーブ")]
                Sleeve = 1,

                /// <summary>
                /// ハイリング
                /// </summary>                
                [attEnumLabel("ハイリング")]
                HiRing = 2,

                /// <summary>
                /// フリードーナツ
                /// </summary>                
                [attEnumLabel("フリードーナツ")]
                FD = 3,

                /// <summary>
                /// OSリング
                /// </summary>
                [attEnumLabel("OSリング")]
                OSRing = 4,

                /// <summary>
                /// EGリング
                /// </summary>
                [attEnumLabel("EGリング")]
                EGRing = 5,
            }

            //-----------------------------------------------------------------
            // Title   : 構成材料種類を定義する列挙体
            // History : 2020/ 3/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 構成材料種類を定義する列挙体
            /// </summary>
            public enum ComponentKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                [attEnumLabel("")]
                Undefined = 0,

                /// <summary>
                /// 部材
                /// </summary>
                [attEnumLabel("鋼材")]
                Buzai = 1,

                /// <summary>
                /// 型板
                /// </summary>
                [attEnumLabel("型板")]
                Kataita = 2,

                /// <summary>
                /// 部品
                /// </summary>
                [attEnumLabel("部品")]
                Buhin = 3,
            }

            //-----------------------------------------------------------------
            // Title   : 構成材料親材料種類
            // History : 2020/ 4/30 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 構成材料親材料種類
            /// </summary>
            public enum ComponentBaseKind
            {
                /// <summary>
                /// 部材
                /// </summary>
                Buzai = 0,

                /// <summary>
                /// 仕口
                /// </summary>
                Shiguchi = 1,

                /// <summary>
                /// 製品
                /// </summary>
                Seihin = 2,
            }

            /// <summary>
            /// 構成材料情報 部品・型紙種類
            /// </summary>
            public enum ComponentType
            {
                /// <summary>
                /// 未定義
                /// </summary>
                [attEnumLabel("")]
                Undefined = 0,

                // 端部材
                //-----------------------------------------------------------------------------
                /// <summary>端部材（CT） ※部品(CT)、型紙(BT)</summary>
                [attEnumLabel("端部材（CT）")]
                MaterialEdge_CT = 1,

                /// <summary>端部材（羽子板） ※型紙</summary>
                [attEnumLabel("端部材（羽子板）")]
                MaterialEdge_Hago = 2,

                /// <summary>端部材（挟み板） ※型紙</summary>
                [attEnumLabel("端部材（挟み板）")]
                MaterialEdge_Plt = 3,

                /// <summary>端部材（十字） ※型紙</summary>
                [attEnumLabel("端部材（十字）")]
                MaterialEdge_Cross = 4,

                /// <summary>塞ぎ部材</summary>
                [attEnumLabel("塞ぎ部材")]
                MaterialPlug = 5,

                /// <summary>端部材キャップ ※部品</summary>
                [attEnumLabel("端部材キャップ")]
                MaterialCap = 50,


                // 仕口
                //-----------------------------------------------------------------------------
                /// <summary>仕口 通しダイアフラム ※型紙</summary>
                [attEnumLabel("通しダイア")]
                Core_TDia = 6,

                /// <summary>仕口 内ダイアフラム ※型紙</summary>
                [attEnumLabel("内ダイア")]
                Core_IDia = 7,

                /// <summary>仕口 スチフナー ※型紙</summary>
                [attEnumLabel("スチフナー")]
                Core_Stiffener = 97,

                /// <summary>仕口 パネル ※型紙</summary>
                [attEnumLabel("パネル")]
                Core_Panel = 8,


                // 継手、ベース
                //-----------------------------------------------------------------------------
                /// <summary>アンカーベース ※部品、型紙</summary>
                [attEnumLabel("ベース")]
                AnchorBase = 9,

                /// <summary>ベース ※部品、型紙</summary>
                [attEnumLabel("ベース")]
                Base = 10,

                /// <summary>ベース補強板 ※型紙</summary>
                [attEnumLabel("ベース補強板")]
                BaseSupPL = 96,

                /// <summary>ベースリブ ※型紙</summary>
                [attEnumLabel("ベースリブ")]
                BaseRib = 11,

                /// <summary>セットバックプレート ※型紙</summary>
                [attEnumLabel("セットバックプレート")]
                SetbackPL = 12,

                /// <summary>合掌プレート ※型紙</summary>
                [attEnumLabel("合掌プレート")]
                JointPL = 13,

                /// <summary>柱ガセット ※型紙</summary>
                [attEnumLabel("柱ガセット")]
                Gusset_Column = 14,

                /// <summary>間柱ガセット ※型紙</summary>
                [attEnumLabel("間柱ガセット")]
                Gusset_Post = 15,

                /// <summary>梁ガセット ※型紙</summary>
                [attEnumLabel("梁ガセット")]
                Gusset_Girder = 16,

                /// <summary>スプライス</summary>
                [attEnumLabel("スプライス")]
                Splice = 17,

                /// <summary>スプライスフィラー</summary>
                [attEnumLabel("スプライスフィラー")]
                SpliceFiller = 18,

                /// <summary>エレクションピース</summary>
                [attEnumLabel("エレクションピース")]
                ErectionPiece = 19,

                /// <summary>エレクション通し板 ※型紙</summary>
                [attEnumLabel("エレクション通し板")]
                ErectionPiece_ThroughPL = 108,

                /// <summary>コラム補強板（エレクションピース トッププレート）</summary>
                [attEnumLabel("コラム補強板")]
                ErectionPiece_TopPL = 52,

                /// <summary>鋼管継手 フランジ板 ※型紙</summary>
                [attEnumLabel("鋼管継手 フランジ板")]
                JointPipe_FLG = 65,

                /// <summary>鋼管継手 フランジリブ ※型紙</summary>
                [attEnumLabel("鋼管継手 フランジリブ")]
                JointPipe_FLGRib = 66,

                /// <summary>コラムカプラ ※部品</summary>
                [attEnumLabel("コラムカプラ")]
                ColumnCoupler = 109,


                /// <summary>スプリットＴ ※部品</summary>
                [attEnumLabel("スプリットＴ")]
                SplitT = 20,

                /// <summary>鋼材（継手マスタ種類が[鋼材],[２面せん断（ガセット種類がＴ形鋼）]） ※部品</summary>
                [attEnumLabel("鋼材")]
                Material = 21,

                /// <summary>ブレースシート ※型紙</summary>
                [attEnumLabel("ブレースシート")]
                BraceSheet = 22,

                /// <summary>既製品ブレースシート ※部品、型紙</summary>
                [attEnumLabel("既製品ブレースシート")]
                BraceSheet_ReadyMade = 57,

                /// <summary>ブレースシート一体ガセット ※型紙</summary>
                [attEnumLabel("ブレースシート一体ガセット")]
                BraceCombi = 23,

                /// <summary>亀の甲 ※型紙</summary>
                [attEnumLabel("亀の甲")]
                BraceKm = 24,

                /// <summary>ブレースシート割り込み板 ※型紙</summary>
                [attEnumLabel("ブレースシート割り込み板")]
                BraceCorbelPL = 49,

                /// <summary>ブレースリブ（三角リブ）</summary>
                [attEnumLabel("ブレースリブ（三角リブ）")]
                BraceTriangleRib = 58,

                /// <summary>ブレースリブ（シートリブ）</summary>
                [attEnumLabel("ブレースリブ（シートリブ）")]
                BraceSheetRib = 59,

                /// <summary>
                /// ワッシャー ※部品
                /// <para>※ボルト接合で生成されるワッシャー</para>
                /// </summary>
                [attEnumLabel("ワッシャー")]
                Washer = 62,

                /// <summary>
                /// フィラー ※型紙
                /// <para>※ボルト接合で生成される挟み板</para>
                /// </summary>
                [attEnumLabel("フィラー")]
                Filler = 63,


                /// <summary>コーナーピース ※部品、型紙</summary>
                [attEnumLabel("コーナーピース")]
                PieceCorner = 25,

                /// <summary>接続ピース ※部品、型紙</summary>
                [attEnumLabel("接続ピース")]
                PieceConnect = 26,

                /// <summary>支持ピース ※部品、型紙</summary>
                [attEnumLabel("支持ピース")]
                PieceSupport = 27,

                /// <summary>ピースリブ ※型紙</summary>
                [attEnumLabel("ピースリブ")]
                PieceRib = 71,


                /// <summary>スチフナー ※型紙</summary>
                [attEnumLabel("スチフナー")]
                Stiffener = 28,

                /// <summary>組合せフィラー ※部品</summary>
                [attEnumLabel("組合せフィラー")]
                PairFiller = 29,

                /// <summary>腹側フィラー ※部品</summary>
                [attEnumLabel("腹側フィラー")]
                RipFiller = 30,

                // ※エンドプレートに改名するために廃止（'2015/09/15 - 升本 吉昭）
                ///// <summary>先端プレート</summary>
                //EdgePlate = 31,

                /// <summary>エンドプレート</summary>
                [attEnumLabel("エンドプレート")]
                EndPlate = 31,

                /// <summary>サイドプレート ※部品</summary>
                [attEnumLabel("サイドプレート")]
                SidePL = 53,


                /// <summary>リブ・スチフナー（リブ） ※型紙</summary>
                [attEnumLabel("リブ")]
                RibStiffener_Rib = 32,

                /// <summary>リブ・スチフナー（スチフナー） ※型紙</summary>
                [attEnumLabel("スチフナー")]
                RibStiffener_Stiffener = 33,

                /// <summary>ハンチ補強板（リブ） ※部品</summary>
                [attEnumLabel("ハンチ補強板（リブ）")]
                HanceRib_Rib = 54,

                /// <summary>ハンチ補強板（スチフナー） ※型紙</summary>
                [attEnumLabel("ハンチ補強板（スチフナー）")]
                HanceRib_Stiffener = 55,


                /// <summary>三角リブ ※型紙</summary>
                [attEnumLabel("三角リブ")]
                TriangleRib = 34,

                /// <summary>補強部材</summary>
                [attEnumLabel("補強部材")]
                Reinforcing = 35,


                /// <summary>付けフランジ ※型紙</summary>
                [attEnumLabel("付けフランジ")]
                ConnectFLG = 70,


                // ハンチ鋼材
                //-----------------------------------------------------------------------------
                /// <summary>ＢＨ フランジ ※型紙</summary>
                [attEnumLabel("ＢＨ フランジ")]
                BH_FLG = 36,

                /// <summary>ＢＨ ウェブ ※型紙</summary>
                [attEnumLabel("ＢＨ ウェブ")]
                BH_WEB = 37,

                /// <summary>ハンチ三角プレート ※型紙</summary>
                [attEnumLabel("ハンチ三角プレート")]
                HanceTriPL = 38,

                /// <summary>ハンチ展開プレート フランジ ※型紙</summary>
                [attEnumLabel("ハンチ展開プレート フランジ")]
                HancePL_FLG = 39,

                /// <summary>ハンチ展開プレート ウェブ ※型紙</summary>
                [attEnumLabel("ハンチ展開プレート ウェブ")]
                HancePL_WEB = 40,

                /// <summary>
                /// ビルド材 ※型紙
                /// <para>※ビルド材を構成する板。</para>
                /// <para>※ＢＨ～系と似てるが、型紙図番としては[鋼材符号名＋"位置を示すキーワード"]で固定的に決定する。</para>
                /// </summary>
                [attEnumLabel("ビルド材")]
                BuildMaterial = 94,


                // 二次部材
                //-----------------------------------------------------------------------------
                /// <summary>スリーブ ※部品、型紙</summary>
                [attEnumLabel("スリーブ")]
                Sleeve = 41,

                /// <summary>かさ上げ継板 ※部品</summary>
                [attEnumLabel("かさ上げ継板")]
                RaiseBz_JointPL = 51,

                /// <summary>デッキ受け ※部品</summary>
                [attEnumLabel("デッキ受け")]
                DeckSubPL = 42,

                /// <summary>ネットフック ※部品</summary>
                [attEnumLabel("ネットフック")]
                NetHook = 43,

                /// <summary>吊ピース ※部品</summary>
                [attEnumLabel("吊ピース")]
                HangPiece = 44,

                /// <summary>建入直しピース ※部品</summary>
                [attEnumLabel("建入直しピース")]
                BuiltPiece = 45,

                /// <summary>親綱ピース ※部品</summary>
                [attEnumLabel("親綱ピース")]
                LifelinePiece = 46,

                /// <summary>梁下がり止めピース ※部品</summary>
                [attEnumLabel("梁下がり止めピース")]
                FallStopPiece = 56,

                /// <summary>
                /// 特殊部品 構成板 ※型紙
                /// <para>※特殊部品マスター 鋼材の対応に伴い、構成鋼材もこれを使用します。</para>
                /// </summary>
                [attEnumLabel("特殊部品 構成板")]
                PartsEx = 64,

                /// <summary>カンザシ ※部品</summary>
                [attEnumLabel("カンザシ")]
                Kanzashi = 67,

                /// <summary>ハイステージ ※部品</summary>
                [attEnumLabel("ハイステージ")]
                HighStage = 68,

                /// <summary>SRCバンド ※部品</summary>
                [attEnumLabel("SRCバンド")]
                SRCBand = 69,

                /// <summary>カバープレート ※型紙</summary>
                [attEnumLabel("カバープレート")]
                CoverPL = 93,

                /// <summary>水切りプレート ※型紙</summary>
                [attEnumLabel("水切りプレート")]
                Weatherboard = 114,


                // 住金システム建築 用（'2017/08/30 - 升本 吉昭）
                //-----------------------------------------------------------------------------
                // ※住金システム建築 柱BOX型柱脚支承板仕様
                //    │:          :│
                //    │:    柱    :│            ┌──────┐
                //    │:          :│            │    ┌リブ通しPL 
                //  ┌────────台座PL      │    ││    │
                //  └┬──┬┬──┬┘          │┌─┤├─┐│
                //     ＼   ││   ／             │└─┤├─リブPL
                //       ＼ ││ ／               │    ││    │
                //      ┌┴┴┴┴┐              │    └┘    │
                //      └────上部B.PL        └──────┘
                //
                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 台座PL</summary>
                [attEnumLabel("住金柱脚台座PL")]
                zSumikin_QFU_PedestalPL = 98,

                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 上部B.PL</summary>
                [attEnumLabel("住金柱脚上部B.PL")]
                zSumikin_QFU_UpBasePL = 99,

                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 リブ通しPL</summary>
                [attEnumLabel("住金柱脚リブ通しPL")]
                zSumikin_QFU_RibTPL = 100,

                /// <summary>住金システム建築 柱BOX型柱脚支承板仕様 リブPL</summary>
                [attEnumLabel("住金柱脚リブPL")]
                zSumikin_QFU_RibPL = 101,

                // ※住金システム建築 継手
                //                                              ┌┐        ┏フランジPL
                //                                              ││        ┃┃│
                //                                              ││        ┗┛│
                //                                              │└─────┘│
                //                                              │┌─────┐│
                //                                              ││        ┏┓│
                //  ┌──────────スプリットプレート    ││        ┃┃│
                //  └┬────┬────┘                    └┘        ┗┛┘
                //    │        │=========フィラープレート
                //    │        │┌──────────        ││          ││
                //    │        ││￣￣￣￣￣￣￣￣￣￣        ││          │┌┐
                //    │        ││                            ││        ┏┓││
                //    │        ││                            ││        ┃┃││
                //    │        ││                            ││        ┃┃│└─────┐
                //    │        ││＿＿＿＿＿＿＿＿＿＿        ││        ┃┃│┌─────スプリットティ
                //  ┌┴────┴└───┬──────        ││        ┃┃││
                //  └┬────┬────スプリットプレート    ││        ┗┛││
                //    │        │                              ││          │└┘
                //    │        │                              ││          ││
                ///// <summary>住金システム建築 継手 スプリットプレート</summary>
                //zSumikin_Joint_SplitPL = 102,

                /// <summary>住金システム建築 継手 フィラープレート</summary>
                [attEnumLabel("住金継手フィラープレート")]
                zSumikin_Joint_Filler = 103,

                /// <summary>住金システム建築 継手 スプリットティ フランジPL</summary>
                [attEnumLabel("住金継手TフランジPL")]
                zSumikin_Joint_SplitT_FLGPL = 104,

                /// <summary>住金システム建築 継手 スプリットティ ウェブPL</summary>
                [attEnumLabel("住金継手TウェブPL")]
                zSumikin_Joint_SplitT_WEBPL = 105,

                /// <summary>住金システム建築 継手 スプリットティ リブPL</summary>
                [attEnumLabel("住金継手TリブPL")]
                zSumikin_Joint_SplitT_RibPL = 106,

                // ※住金システム建築 母屋ピース
                //          ┌───┐
                //          │  ○  │
                //  ┌───┘      │
                //  │  ○      ○  │
                //  │             ／
                //  │           ／
                //  │  ○     ／
                //  └────
                /// <summary>住金システム建築 母屋ピース YKピース</summary>
                [attEnumLabel("住金母屋YKピース")]
                zSumikin_RoofPiece_YKPiece = 107,

                // ※住金システム建築 Tio柱脚 TK金物
                //  │|                          |│
                //  │|                          |│
                //  │|                          |│
                //  │| ┌TK金物───────┐ |│
                //  │| │  ┏┓  ┏┓  ┏リブPL |│
                //  │| │○┃┃○┃┃○┃┃○│ |│
                //  │| │  ┃┃  ┃┃  ┃┃  │ |│
                //  │| │○┃┃  ┃┃  ┃┃○│ |│
                //  └─│＿┗┛＿┗┛＿┗┛＿│─┘
                //      └──────────┘
                /// <summary>住金システム建築 Tio柱脚 TK金物</summary>
                [attEnumLabel("住金Tio柱脚 TK金物")]
                zSumikin_TioTK = 110,

                /// <summary>住金システム建築 Tio柱脚 TK金物 リブPL</summary>
                [attEnumLabel("住金Tio柱脚 リブPL")]
                zSumikin_TioTK_RibPL = 111,

                // ※住金システム建築 スプライス
                //
                //            ┏━━━━━━━━━━リブPL
                //            ┃                    ┃
                //          ┌┗━━━━━━━━━━┛┐
                //  ────└────────────┘────
                //  ￣￣￣￣￣￣￣￣￣￣││￣￣￣￣￣￣￣￣￣￣
                //                      ││
                //                      ││
                //                      ││
                //  ＿＿＿＿＿＿＿＿＿＿││＿＿＿＿＿＿＿＿＿＿
                //  ────┌────────────┐────
                //          └┏━━━━━━━━━━┓┘
                //            ┃                    ┃
                //            ┗━━━━━━━━━━リブPL
                //
                /// <summary>住金システム建築 スプライス リブPL</summary>
                [attEnumLabel("住金スプライス リブPL")]
                zSumikin_Splice_RibPL = 112,
                //-----------------------------------------------------------------------------


                // 管理資料用
                //-----------------------------------------------------------------------------
                /// <summary>ターンバックル</summary>
                [attEnumLabel("ターンバックル")]
                xTurnBuckle = 47,

                /// <summary>アンカーボルト 定着板</summary>
                [attEnumLabel("アンカーボルト 定着板")]
                xAnchorFixPL = 113,

                /// <summary>裏当て金</summary>
                [attEnumLabel("裏当て金")]
                xBackingMetal = 48,

                /// <summary>エンドタブ</summary>
                [attEnumLabel("エンドタブ")]
                xEndTab = 95,

                /// <summary>ドーブチ部品</summary>
                [attEnumLabel("ドーブチ部品")]
                xDBCParts = 60,

                /// <summary>二次部材 穴セット（ボルト）</summary>
                [attEnumLabel("二次部材 穴セット（ボルト）")]
                xSecHoleBolt = 61,


                // 母屋
                /// <summary>母屋端部材（CT） ※部品(CT)、型紙(BT)</summary>
                [attEnumLabel("母屋端部材（CT）")]
                xRoof_MaterialEdge_CT = 72,

                /// <summary>母屋塞ぎ部材</summary>
                [attEnumLabel("母屋塞ぎ部材")]
                xRoof_MaterialPlug = 73,

                /// <summary>母屋コーナーピース ※部品、型紙</summary>
                [attEnumLabel("母屋コーナーピース")]
                xRoof_PieceCorner = 74,

                /// <summary>母屋接続ピース ※部品、型紙</summary>
                [attEnumLabel("母屋接続ピース")]
                xRoof_PieceConnect = 75,

                /// <summary>母屋支持ピース ※部品、型紙</summary>
                [attEnumLabel("母屋支持ピース")]
                xRoof_PieceSupport = 76,

                /// <summary>母屋ピースリブ ※型紙</summary>
                [attEnumLabel("母屋ピースリブ")]
                xRoof_PieceRib = 77,

                /// <summary>母屋組合せフィラー ※部品</summary>
                [attEnumLabel("母屋組合せフィラー")]
                xRoof_PairFiller = 78,

                /// <summary>母屋腹側フィラー ※部品</summary>
                [attEnumLabel("母屋腹側フィラー")]
                xRoof_RipFiller = 79,

                /// <summary>母屋補強部材</summary>
                [attEnumLabel("母屋補強部材")]
                xRoof_Reinforcing = 80,


                // 胴縁
                /// <summary>胴縁端部材（CT） ※部品(CT)、型紙(BT)</summary>
                [attEnumLabel("胴縁端部材（CT）")]
                xWall_MaterialEdge_CT = 81,

                /// <summary>胴縁塞ぎ部材</summary>
                [attEnumLabel("胴縁塞ぎ部材")]
                xWall_MaterialPlug = 82,

                /// <summary>胴縁アンカーベース ※部品、型紙</summary>
                [attEnumLabel("胴縁アンカーベース")]
                xWall_AnchorBase = 83,

                /// <summary>胴縁ベース ※部品、型紙</summary>
                [attEnumLabel("胴縁ベース")]
                xWall_Base = 84,

                /// <summary>胴縁ベースリブ ※型紙</summary>
                [attEnumLabel("胴縁ベースリブ")]
                xWall_BaseRib = 85,

                /// <summary>胴縁コーナーピース ※部品、型紙</summary>
                [attEnumLabel("胴縁コーナーピース")]
                xWall_PieceCorner = 86,

                /// <summary>胴縁接続ピース ※部品、型紙</summary>
                [attEnumLabel("胴縁接続ピース")]
                xWall_PieceConnect = 87,

                /// <summary>胴縁支持ピース ※部品、型紙</summary>
                [attEnumLabel("胴縁支持ピース")]
                xWall_PieceSupport = 88,

                /// <summary>胴縁ピースリブ ※型紙</summary>
                [attEnumLabel("胴縁ピースリブ")]
                xWall_PieceRib = 89,

                /// <summary>胴縁組合せフィラー ※部品</summary>
                [attEnumLabel("胴縁組合せフィラー")]
                xWall_PairFiller = 90,

                /// <summary>胴縁腹側フィラー ※部品</summary>
                [attEnumLabel("胴縁腹側フィラー")]
                xWall_RipFiller = 91,

                /// <summary>胴縁補強部材</summary>
                [attEnumLabel("胴縁補強部材")]
                xWall_Reinforcing = 92,



                // Max=114
            }
        }//End Class

        //---------------------------------------------------------------------
        // Title   : 構造体 格納クラス
        // Date    : 2020/ 4/20
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 構造体 格納クラス
        /// </summary>
        public class typ
        {
            //-------------------------------------------------------------------------
            // Title   : ３Ｄ構造マーカーインターフェース
            // Date    : 2020/ 4/20
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ３Ｄ構造マーカーインターフェース
            /// </summary>
            public interface ICoord
            { }

            //-------------------------------------------------------------------------
            // Title   : ３Ｄ構造
            // Date    : 2020/ 4/20
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ３Ｄ構造
            /// </summary>
            public class Coord : ICoord
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Coord()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Coord(Coord vobjOther)
                {
                    this.Core = new zPMxCom.typ.Line3D(vobjOther.Core);
                    this.Center = new zPMxCom.typ.Line3D(vobjOther.Center);
                    this.FrameLU = new zPMxCom.typ.Line3D(vobjOther.FrameLU);
                    this.FrameRU = new zPMxCom.typ.Line3D(vobjOther.FrameRU);
                    this.FrameLD = new zPMxCom.typ.Line3D(vobjOther.FrameLD);
                    this.FrameRD = new zPMxCom.typ.Line3D(vobjOther.FrameRD);
                }

                /// <summary>
                /// 部材芯
                /// </summary>
                public zPMxCom.typ.Line3D Core = new zPMxCom.typ.Line3D();

                /// <summary>
                /// 中心
                /// </summary>
                public zPMxCom.typ.Line3D Center = new zPMxCom.typ.Line3D();

                /// <summary>
                /// 部材枠 左上
                /// </summary>
                public zPMxCom.typ.Line3D FrameLU = new zPMxCom.typ.Line3D();

                /// <summary>
                /// 部材枠 右上
                /// </summary>
                public zPMxCom.typ.Line3D FrameRU = new zPMxCom.typ.Line3D();

                /// <summary>
                /// 部材枠 左下
                /// </summary>
                public zPMxCom.typ.Line3D FrameLD = new zPMxCom.typ.Line3D();

                /// <summary>
                /// 部材枠 右下
                /// </summary>
                public zPMxCom.typ.Line3D FrameRD = new zPMxCom.typ.Line3D();
            }

            //-------------------------------------------------------------------------
            // Title   : ３Ｄ構造アーチ用
            // Date    : 2020/ 4/20
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ３Ｄ構造アーチ用
            /// </summary>
            public class CoordArch : ICoord
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public CoordArch()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public CoordArch(CoordArch vobjOther)
                {
                    this.Core = new zPMxCom.typ.Arc3D(vobjOther.Core);
                    this.Center = new zPMxCom.typ.Arc3D(vobjOther.Center);
                    this.FrameLU = new zPMxCom.typ.Arc3D(vobjOther.FrameLU);
                    this.FrameRU = new zPMxCom.typ.Arc3D(vobjOther.FrameRU);
                    this.FrameLD = new zPMxCom.typ.Arc3D(vobjOther.FrameLD);
                    this.FrameRD = new zPMxCom.typ.Arc3D(vobjOther.FrameRD);
                }

                /// <summary>
                /// 部材芯
                /// </summary>
                public zPMxCom.typ.Arc3D Core = new zPMxCom.typ.Arc3D();

                /// <summary>
                /// 中心
                /// </summary>
                public zPMxCom.typ.Arc3D Center = new zPMxCom.typ.Arc3D();

                /// <summary>
                /// 部材枠 左上
                /// </summary>
                public zPMxCom.typ.Arc3D FrameLU = new zPMxCom.typ.Arc3D();

                /// <summary>
                /// 部材枠 右上
                /// </summary>
                public zPMxCom.typ.Arc3D FrameRU = new zPMxCom.typ.Arc3D();

                /// <summary>
                /// 部材枠 左下
                /// </summary>
                public zPMxCom.typ.Arc3D FrameLD = new zPMxCom.typ.Arc3D();

                /// <summary>
                /// 部材枠 右下
                /// </summary>
                public zPMxCom.typ.Arc3D FrameRD = new zPMxCom.typ.Arc3D();
            }

            //-------------------------------------------------------------------------
            // Title   : 生産管理システム用施工データ
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 生産管理システム用施工データ
            /// </summary>
            public class PMData
            {
                /// <summary>
                /// 部材情報データ
                /// </summary>
                public List<typ.Buzai> BuzaiData = new List<Buzai>();

                /// <summary>
                /// 製品情報データ
                /// </summary>
                public List<typ.Seihin> SeihinData = new List<Seihin>();

                /// <summary>
                /// 仕口情報データ
                /// </summary>
                public List<typ.Shiguchi> ShiguchiData = new List<Shiguchi>();

                /// <summary>
                /// 型板情報データ
                /// </summary>
                public List<typ.Kataita> KataitaData = new List<Kataita>();

                /// <summary>
                /// 部品情報データ
                /// </summary>
                public List<typ.Buhin> BuhinData = new List<Buhin>();

                /// <summary>
                /// 製作グループデータ
                /// </summary>
                public List<typ.WorkGroup> WorkGroupData = new List<WorkGroup>();

                /// <summary>
                /// 材料グループデータ
                /// </summary>
                public List<typ.ZairyoGroup> ZairyoGroupData = new List<ZairyoGroup>();

                /// <summary>
                /// 出荷グループデータ
                /// </summary>
                public List<typ.ShippingGroup> ShippingGroupData = new List<ShippingGroup>();

                /// <summary>
                /// 通りデータ
                /// </summary>
                public List<typ.Street> StreetData = new List<Street>();

                /// <summary>
                /// キープランデータ
                /// </summary>
                public List<typ.Keyplan> KeyplanData = new List<Keyplan>();

                /// <summary>
                /// 階データ
                /// </summary>
                public List<typ.Floor> FloorData = new List<Floor>();

                /// <summary>
                /// 工区データ
                /// </summary>
                public List<typ.Area> AreaData = new List<Area>();

                /// <summary>
                /// 分類データ
                /// </summary>
                public List<typ.Node> NodeData = new List<Node>();

                /// <summary>
                /// グループデータ
                /// </summary>
                public List<typ.Group> GroupData = new List<Group>();

                /// <summary>
                /// 塗装データ
                /// </summary>
                public List<typ.Paint> PaintData = new List<Paint>();

                /// <summary>
                /// 建方データ
                /// </summary>
                public List<typ.Build> BuildData = new List<Build>();

                /// <summary>
                /// 出荷データ
                /// </summary>
                public List<typ.Ship> ShipData = new List<Ship>();

                /// <summary>
                /// 胴縁パネルデータ
                /// </summary>
                public List<typ.WallPanel> WallPanelData = new List<WallPanel>();

                /// <summary>
                /// 母屋パネルデータ
                /// </summary>
                public List<typ.RoofPanel> RoofPanelData = new List<RoofPanel>();

                /// <summary>
                /// 胴縁配置面データ
                /// </summary>
                public List<typ.WallFace> WallFaceData = new List<WallFace>();

                /// <summary>
                /// 母屋配置面データ
                /// </summary>
                public List<typ.RoofFace> RoofFaceData = new List<RoofFace>();

                /// <summary>
                /// 本体組鋼材データ
                /// </summary>
                public List<typ.Pair> PairData = new List<Pair>();

                /// <summary>
                /// 胴縁組鋼材データ
                /// </summary>
                public List<typ.WallPair> WallPairData = new List<WallPair>();

                /// <summary>
                /// 母屋組鋼材データ
                /// </summary>
                public List<typ.RoofPair> RoofPairData = new List<RoofPair>();
            }

            //-------------------------------------------------------------------------
            // Title   : 工区
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 工区
            /// </summary>
            public class Area : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Area()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Area(Area vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// コード
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: 工区のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolArea          - in 工区
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 工区のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolArea">工区</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Area> vcolArea)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("AreaData");
                            {
                                foreach (zPMxData.typ.Area objArea in vcolArea)
                                {
                                    objWriter.WriteStartElement("Area");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objArea.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objArea.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objArea.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objArea.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objArea.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objArea.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objArea.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objArea.Color);

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objArea.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 工区のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolArea          - out 工区
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 工区のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolArea">工区</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Area> rcolArea)
                {
                    rcolArea = new List<Area>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Area objArea = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Area":
                                        {
                                            objArea = new Area();
                                            rcolArea.Add(objArea);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objArea.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objArea.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objArea.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objArea.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objArea.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objArea.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objArea.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objArea.Color);
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objArea.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 分類
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 分類
            /// </summary>
            public class Node : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Node()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Node(Node vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// コード
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: 分類のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolNode          - in 分類
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 分類のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolNode">分類</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Node> vcolNode)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("NodeData");
                            {
                                foreach (zPMxData.typ.Node objNode in vcolNode)
                                {
                                    objWriter.WriteStartElement("Node");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objNode.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objNode.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objNode.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objNode.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objNode.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objNode.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objNode.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objNode.Color);

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objNode.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 分類のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolNode          - out 分類
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 分類のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolNode">分類</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Node> rcolNode)
                {
                    rcolNode = new List<Node>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Node objNode = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Node":
                                        {
                                            objNode = new Node();
                                            rcolNode.Add(objNode);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objNode.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objNode.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objNode.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objNode.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objNode.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objNode.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objNode.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objNode.Color);
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objNode.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : グループ
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// グループ
            /// </summary>
            public class Group : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Group()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Group(Group vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.Blasting = vobjOther.Blasting;
                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// コード
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// ショットブラスト有無
                /// </summary>
                public bool Blasting = false;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: グループのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolGroup          - in グループ
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// グループのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolGroup">グループ</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Group> vcolGroup)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("GroupData");
                            {
                                foreach (zPMxData.typ.Group objGroup in vcolGroup)
                                {
                                    objWriter.WriteStartElement("Group");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objGroup.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objGroup.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objGroup.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objGroup.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objGroup.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objGroup.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objGroup.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objGroup.Color);

                                        objWriter.WriteStartElement("Blasting");
                                        {
                                            objWriter.WriteString(objGroup.Blasting.ToString().ToLower());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objGroup.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: グループのXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolGroup          - out グループ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// グループのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolGroup">グループ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Group> rcolGroup)
                {
                    rcolGroup = new List<Group>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Group objGroup = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Group":
                                        {
                                            objGroup = new Group();
                                            rcolGroup.Add(objGroup);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objGroup.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objGroup.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objGroup.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objGroup.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objGroup.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objGroup.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objGroup.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objGroup.Color);
                                        }
                                        break;

                                    case "Blasting":
                                        {
                                            objGroup.Blasting = objReader.ReadElementContentAsBoolean();
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objGroup.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 塗装
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 塗装
            /// </summary>
            public class Paint : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Paint()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Paint(Paint vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.Remarks = vobjOther.Remarks;
                    this.MstID = vobjOther.MstID;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// コード
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                /// <summary>
                /// 塗装マスターID
                /// </summary>
                public int MstID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 塗装のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolPaint         - in 塗装
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 塗装のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolPaint">塗装</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Paint> vcolPaint)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("PaintData");
                            {
                                foreach (zPMxData.typ.Paint objPaint in vcolPaint)
                                {
                                    objWriter.WriteStartElement("Paint");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objPaint.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objPaint.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objPaint.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objPaint.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objPaint.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objPaint.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objPaint.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objPaint.Color);

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objPaint.Remarks);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("MstID");
                                        {
                                            objWriter.WriteString(objPaint.MstID.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 塗装のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolPaint          - out 塗装
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 塗装のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolPaint">塗装</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Paint> rcolPaint)
                {
                    rcolPaint = new List<Paint>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Paint objPaint = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Paint":
                                        {
                                            objPaint = new Paint();
                                            rcolPaint.Add(objPaint);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objPaint.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objPaint.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objPaint.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objPaint.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objPaint.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objPaint.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objPaint.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objPaint.Color);
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objPaint.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "MstID":
                                        {
                                            objPaint.MstID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 建方
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 建方
            /// </summary>
            public class Build : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Build()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Build(Build vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// コード
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: 建方のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolBuild         - in 建方
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 建方のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolBuild">建方</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Build> vcolBuild)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("BuildData");
                            {
                                foreach (zPMxData.typ.Build objBuild in vcolBuild)
                                {
                                    objWriter.WriteStartElement("Build");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objBuild.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objBuild.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objBuild.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objBuild.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objBuild.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objBuild.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objBuild.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objBuild.Color);

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objBuild.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 建方のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolBuild         - out 建方
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 建方のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolBuild">建方</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Build> rcolBuild)
                {
                    rcolBuild = new List<Build>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Build objBuild = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Build":
                                        {
                                            objBuild = new Build();
                                            rcolBuild.Add(objBuild);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objBuild.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objBuild.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objBuild.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objBuild.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objBuild.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objBuild.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objBuild.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objBuild.Color);
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objBuild.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 出荷
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 出荷
            /// </summary>
            public class Ship : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Ship()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Ship(Ship vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// コード
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: 出荷のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolShip          - in 出荷
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 出荷のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolShip">出荷</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Ship> vcolShip)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("ShipData");
                            {
                                foreach (zPMxData.typ.Ship objShip in vcolShip)
                                {
                                    objWriter.WriteStartElement("Ship");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objShip.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objShip.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objShip.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objShip.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objShip.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objShip.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objShip.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objShip.Color);

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objShip.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 出荷のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolShip          - out 出荷
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 出荷のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolShip">出荷</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Ship> rcolShip)
                {
                    rcolShip = new List<Ship>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Ship objShip = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Ship":
                                        {
                                            objShip = new Ship();
                                            rcolShip.Add(objShip);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objShip.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objShip.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objShip.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objShip.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objShip.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objShip.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objShip.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objShip.Color);
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objShip.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 胴縁パネル
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 胴縁パネル
            /// </summary>
            public class WallPanel : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public WallPanel()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WallPanel(WallPanel vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.NickName = vobjOther.NickName;
                    this.Color = vobjOther.Color;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 管理名
                /// </summary>
                public string NickName = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 胴縁パネルのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolWallPanel     - in 胴縁パネル
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 胴縁パネルのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolWallPanel">胴縁パネル</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.WallPanel> vcolWallPanel)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("WallPanelData");
                            {
                                foreach (zPMxData.typ.WallPanel objWallPanel in vcolWallPanel)
                                {
                                    objWriter.WriteStartElement("WallPanel");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objWallPanel.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objWallPanel.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objWallPanel.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objWallPanel.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objWallPanel.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objWallPanel.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("NickName");
                                        {
                                            objWriter.WriteString(objWallPanel.NickName);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objWallPanel.Color);
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 胴縁パネルのXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolWallPanel     - out 胴縁パネル
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 胴縁パネルのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolWallPanel">胴縁パネル</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.WallPanel> rcolWallPanel)
                {
                    rcolWallPanel = new List<WallPanel>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.WallPanel objWallPanel = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "WallPanel":
                                        {
                                            objWallPanel = new WallPanel();
                                            rcolWallPanel.Add(objWallPanel);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objWallPanel.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objWallPanel.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objWallPanel.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objWallPanel.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objWallPanel.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objWallPanel.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "NickName":
                                        {
                                            objWallPanel.NickName = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objWallPanel.Color);
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 母屋パネル
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 母屋パネル
            /// </summary>
            public class RoofPanel : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public RoofPanel()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public RoofPanel(RoofPanel vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.NickName = vobjOther.NickName;
                    this.Color = vobjOther.Color;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 管理名
                /// </summary>
                public string NickName = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 母屋パネルのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolRoofPanel     - in 母屋パネル
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 母屋パネルのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolRoofPanel">母屋パネル</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.RoofPanel> vcolRoofPanel)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("RoofPanelData");
                            {
                                foreach (zPMxData.typ.RoofPanel objRoofPanel in vcolRoofPanel)
                                {
                                    objWriter.WriteStartElement("RoofPanel");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objRoofPanel.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objRoofPanel.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objRoofPanel.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objRoofPanel.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objRoofPanel.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objRoofPanel.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("NickName");
                                        {
                                            objWriter.WriteString(objRoofPanel.NickName);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objRoofPanel.Color);
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 母屋パネルのXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolRoofPanel     - out 母屋パネル
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 母屋パネルのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolRoofPanel">母屋パネル</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.RoofPanel> rcolRoofPanel)
                {
                    rcolRoofPanel = new List<RoofPanel>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.RoofPanel objRoofPanel = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "RoofPanel":
                                        {
                                            objRoofPanel = new RoofPanel();
                                            rcolRoofPanel.Add(objRoofPanel);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objRoofPanel.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objRoofPanel.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objRoofPanel.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objRoofPanel.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objRoofPanel.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objRoofPanel.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "NickName":
                                        {
                                            objRoofPanel.NickName = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objRoofPanel.Color);
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 胴縁配置面
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 胴縁配置面
            /// </summary>
            public class WallFace : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public WallFace()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WallFace(WallFace vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.Code = vobjOther.Code;
                    this.BaseLine = new zPMxCom.typ.Line(vobjOther.BaseLine);
                    this.Offset = vobjOther.Offset;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 認識符号
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 平面基準ライン
                /// </summary>
                public zPMxCom.typ.Line BaseLine;

                /// <summary>
                /// オフセット
                /// </summary>
                public double Offset;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 胴縁配置面のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolWallFace     - in 胴縁配置面
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 胴縁配置面のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolWallFace">胴縁配置面</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.WallFace> vcolWallFace)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("WallFaceData");
                            {
                                foreach (zPMxData.typ.WallFace objWallFace in vcolWallFace)
                                {
                                    objWriter.WriteStartElement("WallFace");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objWallFace.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objWallFace.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objWallFace.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objWallFace.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objWallFace.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objWallFace.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objWallFace.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        msubWrite_Point(objWriter, "BaseLine_Ps", objWallFace.BaseLine.Ps);

                                        msubWrite_Point(objWriter, "BaseLine_Pe", objWallFace.BaseLine.Pe);

                                        objWriter.WriteStartElement("Offset");
                                        {
                                            objWriter.WriteString(objWallFace.Offset.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 胴縁配置面のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolWallFace      - out 胴縁配置面
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 胴縁配置面のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolWallFace">胴縁配置面</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.WallFace> rcolWallFace)
                {
                    rcolWallFace = new List<WallFace>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.WallFace objWallFace = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "WallFace":
                                        {
                                            objWallFace = new WallFace();
                                            rcolWallFace.Add(objWallFace);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objWallFace.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objWallFace.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objWallFace.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objWallFace.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objWallFace.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objWallFace.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objWallFace.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "BaseLine_Ps":
                                        {
                                            if (objWallFace.BaseLine == null)
                                            {
                                                objWallFace.BaseLine = new zPMxCom.typ.Line();
                                            }

                                            msubRead_Point(objReader.ReadSubtree(), out objWallFace.BaseLine.Ps);
                                        }
                                        break;

                                    case "BaseLine_Pe":
                                        {
                                            if (objWallFace.BaseLine == null)
                                            {
                                                objWallFace.BaseLine = new zPMxCom.typ.Line();
                                            }

                                            msubRead_Point(objReader.ReadSubtree(), out objWallFace.BaseLine.Pe);
                                        }
                                        break;

                                    case "Offset":
                                        {
                                            objWallFace.Offset = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 母屋配置面
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 母屋配置面
            /// </summary>
            public class RoofFace : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public RoofFace()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public RoofFace(RoofFace vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.FloorID = vobjOther.FloorID;
                    this.KpArea.AddRange(vobjOther.KpArea);
                    this.Vector = vobjOther.Vector;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 階高ID
                /// </summary>
                public int FloorID;

                /// <summary>
                /// キープラン範囲
                /// </summary>
                public List<zPMxCom.typ.Point> KpArea = new List<zPMxCom.typ.Point>();

                /// <summary>
                /// 勾配面の傾きを示す法線単位ベクトル
                /// </summary>
                public zPMxCom.typ.Point3D Vector;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 母屋配置面のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolRoofFace     - in 母屋配置面
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 母屋配置面のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolRoofFace">母屋配置面</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.RoofFace> vcolRoofFace)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("RoofFaceData");
                            {
                                foreach (zPMxData.typ.RoofFace objRoofFace in vcolRoofFace)
                                {
                                    objWriter.WriteStartElement("RoofFace");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objRoofFace.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objRoofFace.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objRoofFace.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objRoofFace.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objRoofFace.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objRoofFace.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("FloorID");
                                        {
                                            objWriter.WriteString(objRoofFace.FloorID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KpArea");
                                        {
                                            foreach (zPMxCom.typ.Point usrPoint in objRoofFace.KpArea)
                                            {
                                                msubWrite_Point(objWriter, "Pos", usrPoint);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        msubWrite_Point3D(objWriter, "Vector", objRoofFace.Vector);
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 母屋配置面のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolRoofFace     - out 母屋配置面
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 母屋配置面のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolRoofFace">母屋配置面</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.RoofFace> rcolRoofFace)
                {
                    rcolRoofFace = new List<RoofFace>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.RoofFace objRoofFace = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "RoofFace":
                                        {
                                            objRoofFace = new RoofFace();
                                            rcolRoofFace.Add(objRoofFace);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objRoofFace.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objRoofFace.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objRoofFace.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objRoofFace.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objRoofFace.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objRoofFace.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "FloorID":
                                        {
                                            objRoofFace.FloorID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KpArea":
                                        {
                                            msubRead_PointData(objReader.ReadSubtree(), "Pos", ref objRoofFace.KpArea);
                                        }
                                        break;

                                    case "Vector":
                                        {
                                            msubRead_Point3D(objReader.ReadSubtree(), out objRoofFace.Vector);
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 本体組鋼材
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 本体組鋼材
            /// </summary>
            public class Pair : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Pair()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Pair(Pair vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.MainID = vobjOther.MainID;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 代表部材ID
                /// </summary>
                public int MainID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 本体組鋼材のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolPair          - in 本体組鋼材
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 本体組鋼材のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolPair">本体組鋼材</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Pair> vcolPair)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("PairData");
                            {
                                foreach (zPMxData.typ.Pair objPair in vcolPair)
                                {
                                    objWriter.WriteStartElement("Pair");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objPair.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objPair.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objPair.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objPair.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objPair.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objPair.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objPair.Color);

                                        objWriter.WriteStartElement("MainID");
                                        {
                                            objWriter.WriteString(objPair.MainID.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 本体組鋼材のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolPair          - out 本体組鋼材
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 本体組鋼材のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolPair">本体組鋼材</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Pair> rcolPair)
                {
                    rcolPair = new List<Pair>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Pair objPair = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Pair":
                                        {
                                            objPair = new Pair();
                                            rcolPair.Add(objPair);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objPair.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objPair.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objPair.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objPair.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objPair.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objPair.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objPair.Color);
                                        }
                                        break;

                                    case "MainID":
                                        {
                                            objPair.MainID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 胴縁組鋼材
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 胴縁組鋼材
            /// </summary>
            public class WallPair : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public WallPair()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WallPair(WallPair vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.MainID = vobjOther.MainID;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 代表部材ID
                /// </summary>
                public int MainID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 胴縁組鋼材のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolWallPair          - in 胴縁組鋼材
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 胴縁組鋼材のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolWallPair">胴縁組鋼材</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.WallPair> vcolWallPair)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("WallPairData");
                            {
                                foreach (zPMxData.typ.WallPair objWallPair in vcolWallPair)
                                {
                                    objWriter.WriteStartElement("WallPair");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objWallPair.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objWallPair.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objWallPair.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objWallPair.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objWallPair.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objWallPair.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objWallPair.Color);

                                        objWriter.WriteStartElement("MainID");
                                        {
                                            objWriter.WriteString(objWallPair.MainID.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 胴縁組鋼材のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolWallPair        - out 胴縁組鋼材
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 胴縁組鋼材のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolWallPair">胴縁組鋼材</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.WallPair> rcolWallPair)
                {
                    rcolWallPair = new List<WallPair>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.WallPair objWallPair = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "WallPair":
                                        {
                                            objWallPair = new WallPair();
                                            rcolWallPair.Add(objWallPair);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objWallPair.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objWallPair.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objWallPair.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objWallPair.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objWallPair.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objWallPair.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objWallPair.Color);
                                        }
                                        break;

                                    case "MainID":
                                        {
                                            objWallPair.MainID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 母屋組鋼材
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 母屋組鋼材
            /// </summary>
            public class RoofPair : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public RoofPair()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public RoofPair(RoofPair vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                    this.MainID = vobjOther.MainID;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color;

                /// <summary>
                /// 代表部材ID
                /// </summary>
                public int MainID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 母屋組鋼材のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolRoofPair      - in 母屋組鋼材
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 母屋組鋼材のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolRoofPair">母屋組鋼材</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.RoofPair> vcolRoofPair)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("RoofPairData");
                            {
                                foreach (zPMxData.typ.RoofPair objRoofPair in vcolRoofPair)
                                {
                                    objWriter.WriteStartElement("RoofPair");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objRoofPair.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objRoofPair.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objRoofPair.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objRoofPair.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objRoofPair.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objRoofPair.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objRoofPair.Color);

                                        objWriter.WriteStartElement("MainID");
                                        {
                                            objWriter.WriteString(objRoofPair.MainID.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 母屋組鋼材のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolRoofPair      - out 母屋組鋼材
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 母屋組鋼材のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolRoofPair">母屋組鋼材</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.RoofPair> rcolRoofPair)
                {
                    rcolRoofPair = new List<RoofPair>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.RoofPair objRoofPair = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "RoofPair":
                                        {
                                            objRoofPair = new RoofPair();
                                            rcolRoofPair.Add(objRoofPair);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objRoofPair.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objRoofPair.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objRoofPair.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objRoofPair.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objRoofPair.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objRoofPair.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objRoofPair.Color);
                                        }
                                        break;

                                    case "MainID":
                                        {
                                            objRoofPair.MainID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 通り
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 通り
            /// </summary>
            public class Street : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Street()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Street(Street vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.Design = vobjOther.Design;
                    this.Type = vobjOther.Type;
                    this.LineStyle = vobjOther.LineStyle;
                    this.Lines = new zPMxCom.typ.Arc(vobjOther.Lines);
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 設計番号
                /// </summary>
                public string Design = "";

                /// <summary>
                /// 通りタイプ
                /// </summary>
                public enm.StreetType Type = enm.StreetType.Real;

                /// <summary>
                /// 通りラインスタイル
                /// </summary>
                public enm.StreetLineStyle LineStyle = enm.StreetLineStyle.Line;

                /// <summary>
                /// 通りライン
                /// </summary>
                public zPMxCom.typ.Arc Lines = new zPMxCom.typ.Arc();

                //---------------------------------------------------------------------
                //
                // 機能　　　: 通りのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolStreet        - in 通り
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 通りのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolStreet">通り</param>
                public static void Write(string vstrFilePath, List<zPMxData.typ.Street> vcolStreet)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("StreetData");
                            {
                                foreach (zPMxData.typ.Street objStreet in vcolStreet)
                                {
                                    objWriter.WriteStartElement("Street");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objStreet.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objStreet.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objStreet.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objStreet.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objStreet.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objStreet.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Design");
                                        {
                                            objWriter.WriteString(objStreet.Design);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Type");
                                        {
                                            objWriter.WriteString(objStreet.Type.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("LineStyle");
                                        {
                                            objWriter.WriteString(objStreet.LineStyle.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        msubWrite_Point(objWriter, "Lines_Pc", objStreet.Lines.Pc);

                                        msubWrite_Point(objWriter, "Lines_Ps", objStreet.Lines.Ps);

                                        msubWrite_Point(objWriter, "Lines_Pe", objStreet.Lines.Pe);

                                        objWriter.WriteStartElement("Lines_R");
                                        {
                                            objWriter.WriteString(objStreet.Lines.R.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Lines_Direction");
                                        {
                                            objWriter.WriteString(objStreet.Lines.Direction.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 通りのXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolStreet        - out 通り
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 通りのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolStreet">通り</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath, out List<zPMxData.typ.Street> rcolStreet)
                {
                    rcolStreet = new List<Street>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Street objStreet = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Street":
                                        {
                                            objStreet = new Street();
                                            rcolStreet.Add(objStreet);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objStreet.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objStreet.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objStreet.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objStreet.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objStreet.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objStreet.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Design":
                                        {
                                            objStreet.Design = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Type":
                                        {
                                            objStreet.Type = zPMxCom.Conv_StringToEnum<enm.StreetType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "LineStyle":
                                        {
                                            objStreet.LineStyle = zPMxCom.Conv_StringToEnum<enm.StreetLineStyle>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Lines_Pc":
                                        {
                                            msubRead_Point(objReader.ReadSubtree(), out objStreet.Lines.Pc);
                                        }
                                        break;

                                    case "Lines_Ps":
                                        {
                                            msubRead_Point(objReader.ReadSubtree(), out objStreet.Lines.Ps);
                                        }
                                        break;

                                    case "Lines_Pe":
                                        {
                                            msubRead_Point(objReader.ReadSubtree(), out objStreet.Lines.Pe);
                                        }
                                        break;

                                    case "Lines_R":
                                        {
                                            objStreet.Lines.R = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Lines_Direction":
                                        {
                                            objStreet.Lines.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : キープラン
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// キープラン
            /// </summary>
            public class Keyplan : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Keyplan()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Keyplan(Keyplan vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Name = vobjOther.Name;
                    this.StreetID1 = vobjOther.StreetID1;
                    this.StreetID2 = vobjOther.StreetID2;
                    this.Pos = vobjOther.Pos;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 通りID1
                /// </summary>
                public int StreetID1;

                /// <summary>
                /// 通りID2
                /// </summary>
                public int StreetID2;

                /// <summary>
                /// 交点
                /// </summary>
                public zPMxCom.typ.Point Pos;

                //---------------------------------------------------------------------
                //
                // 機能　　　: キープランのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolKeyplan       - in キープラン
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// キープランのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolKeyplan">キープラン</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.Keyplan> vcolKeyplan)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("KeyplanData");
                            {
                                foreach (zPMxData.typ.Keyplan objKeyplan in vcolKeyplan)
                                {
                                    objWriter.WriteStartElement("Keyplan");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objKeyplan.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objKeyplan.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objKeyplan.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objKeyplan.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objKeyplan.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objKeyplan.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("StreetID1");
                                        {
                                            objWriter.WriteString(objKeyplan.StreetID1.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("StreetID2");
                                        {
                                            objWriter.WriteString(objKeyplan.StreetID2.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        msubWrite_Point(objWriter, "Pos", objKeyplan.Pos);
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: キープランのXML読み込み
                //
                // 引き数　　: vstrFilePath  - in ファイルパス
                // 　　　　　: rcolKeyplan   - out キープラン
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// キープランのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolKeyplan">キープラン</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.Keyplan> rcolKeyplan)
                {
                    rcolKeyplan = new List<Keyplan>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Keyplan objKeyplan = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Keyplan":
                                        {
                                            objKeyplan = new Keyplan();
                                            rcolKeyplan.Add(objKeyplan);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objKeyplan.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objKeyplan.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objKeyplan.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objKeyplan.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objKeyplan.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objKeyplan.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "StreetID1":
                                        {
                                            objKeyplan.StreetID1 = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "StreetID2":
                                        {
                                            objKeyplan.StreetID2 = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Pos":
                                        {
                                            msubRead_Point(objReader.ReadSubtree(), out objKeyplan.Pos);
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 階
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 階
            /// </summary>
            public class Floor : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Floor()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Floor(Floor vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Type = vobjOther.Type;
                    this.Z = vobjOther.Z;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// コード
                /// </summary>
                public string Code = "";

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// タイプ
                /// </summary>
                public enm.FloorType Type = enm.FloorType.Real;

                /// <summary>
                /// 絶対座標
                /// </summary>
                public double Z;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 階のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolFloor         - in 階
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 階のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolFloor">階</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.Floor> vcolFloor)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("FloorData");
                            {
                                foreach (zPMxData.typ.Floor objFloor in vcolFloor)
                                {
                                    objWriter.WriteStartElement("Floor");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objFloor.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objFloor.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objFloor.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objFloor.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objFloor.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objFloor.Code);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objFloor.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Type");
                                        {
                                            objWriter.WriteString(objFloor.Type.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Z");
                                        {
                                            objWriter.WriteString(objFloor.Z.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 階のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolFloor         - out 階
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 階のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolFloor">階</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.Floor> rcolFloor)
                {
                    rcolFloor = new List<Floor>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Floor objFloor = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Floor":
                                        {
                                            objFloor = new Floor();
                                            rcolFloor.Add(objFloor);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objFloor.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objFloor.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objFloor.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objFloor.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objFloor.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objFloor.Code = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objFloor.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Type":
                                        {
                                            objFloor.Type = zPMxCom.Conv_StringToEnum<enm.FloorType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Z":
                                        {
                                            objFloor.Z = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 溶接情報
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 溶接情報
            /// </summary>
            public class WeldInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public WeldInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WeldInfo(WeldInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BaseKind = vobjOther.BaseKind;
                    this.BaseID = vobjOther.BaseID;
                    this.CompID = vobjOther.CompID;
                    this.BuiIndex = vobjOther.BuiIndex;
                    this.ElementKind = vobjOther.ElementKind;
                    this.BasePlateKind = vobjOther.BasePlateKind;
                    this.Kind = vobjOther.Kind;
                    this.Side = vobjOther.Side;
                    this.Place = vobjOther.Place;
                    this.TipKind = vobjOther.TipKind;
                    this.WeldAngle1 = vobjOther.WeldAngle1;
                    this.WeldAngle2 = vobjOther.WeldAngle2;
                    this.WeldDepth1 = vobjOther.WeldDepth1;
                    this.WeldDepth2 = vobjOther.WeldDepth2;
                    this.RG = vobjOther.RG;
                    this.WeldLen = vobjOther.WeldLen;
                    this.UT = vobjOther.UT;
                    this.BPL_KindID = vobjOther.BPL_KindID;
                    this.BPL_StdID = vobjOther.BPL_StdID;
                    this.BPL_Thick = vobjOther.BPL_Thick;
                    this.BPL_Width = vobjOther.BPL_Width;
                    this.BPL_Length = vobjOther.BPL_Length;
                    this.BPL_Count = vobjOther.BPL_Count;
                    this.ET_KindID = vobjOther.ET_KindID;
                    this.ET_StdID = vobjOther.ET_StdID;
                    this.ET_Thick = vobjOther.ET_Thick;
                    this.ET_Width = vobjOther.ET_Width;
                    this.ET_Width2 = vobjOther.ET_Width2;
                    this.ET_Length = vobjOther.ET_Length;
                    this.ET_Count = vobjOther.ET_Count;
                }

                /// <summary>
                /// 親データ種類
                /// </summary>
                public enm.ComponentBaseKind BaseKind = enm.ComponentBaseKind.Buzai;

                /// <summary>
                /// 親データID
                /// </summary>
                public int BaseID;

                /// <summary>
                /// 構成材料情報ID
                /// </summary>
                public int CompID;

                /// <summary>
                /// 溶接部位
                /// </summary>
                public zPMxCom.enm.Weld.BuiIndex BuiIndex = zPMxCom.enm.Weld.BuiIndex.Undefined;

                /// <summary>
                /// 要素種類
                /// </summary>
                public enm.ElementKind ElementKind = enm.ElementKind.Undefined;

                /// <summary>
                /// 溶接元の板の種類
                /// </summary>
                public enm.PlateKind BasePlateKind = enm.PlateKind.Undefined;

                /// <summary>
                /// 溶接種類
                /// </summary>
                public zPMxCom.enm.Weld.Kind Kind = zPMxCom.enm.Weld.Kind.Undefined;

                /// <summary>
                /// 溶接面
                /// </summary>
                public zPMxCom.enm.Weld.Side Side = zPMxCom.enm.Weld.Side.One;

                /// <summary>
                /// 溶接場所
                /// </summary>
                public zPMxCom.enm.Weld.Place Place = zPMxCom.enm.Weld.Place.Fact;

                /// <summary>
                /// 開先形状
                /// </summary>
                public zPMxCom.enm.Weld.TipKind TipKind = zPMxCom.enm.Weld.TipKind.Undefined;

                /// <summary>
                /// 開先角度1
                /// </summary>
                public double WeldAngle1;

                /// <summary>
                /// 開先角度2
                /// </summary>
                public double WeldAngle2;

                /// <summary>
                /// 開先深さ1
                /// </summary>
                public double WeldDepth1;

                /// <summary>
                /// 開先深さ2
                /// </summary>
                public double WeldDepth2;

                /// <summary>
                /// ルートギャップ
                /// </summary>
                public double RG;

                /// <summary>
                /// 溶接長
                /// </summary>
                /// <remarks>
                /// 溶接実長ではありません。
                /// </remarks>
                public double WeldLen;

                /// <summary>
                /// UT箇所数
                /// </summary>
                public int UT;

                /// <summary>
                /// 裏当て金材種ID
                /// </summary>
                public int BPL_KindID;

                /// <summary>
                /// 裏当て金材質ID
                /// </summary>
                public int BPL_StdID;

                /// <summary>
                /// 裏当て金板厚
                /// </summary>
                public double BPL_Thick;

                /// <summary>
                /// 裏当て金幅
                /// </summary>
                public double BPL_Width;

                /// <summary>
                /// 裏当て金長さ
                /// </summary>
                public double BPL_Length;

                /// <summary>
                /// 裏当て金個数
                /// </summary>
                /// <remarks>
                /// 裏当て金分割数
                /// </remarks>
                public int BPL_Count;

                /// <summary>
                /// エンドタブ材種ID
                /// </summary>
                public int ET_KindID;

                /// <summary>
                /// エンドタブ材質ID
                /// </summary>
                public int ET_StdID;

                /// <summary>
                /// エンドタブ板厚
                /// </summary>
                public double ET_Thick;

                /// <summary>
                /// エンドタブ幅
                /// </summary>
                public double ET_Width;

                /// <summary>
                /// エンドタブ幅2
                /// </summary>
                /// <remarks>
                /// B.BOX組み立て溶接の場合に使用
                /// </remarks>
                public double ET_Width2;

                /// <summary>
                /// エンドタブ長さ
                /// </summary>
                public double ET_Length;

                /// <summary>
                /// エンドタブ個数
                /// </summary>
                /// <remarks>
                /// B.BOX組み立て溶接の場合に2となる
                /// </remarks>
                public int ET_Count;
            }

            //-------------------------------------------------------------------------
            // Title   : 切欠き情報
            // Date    : 2020/ 4/24
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 切欠き情報
            /// </summary>
            public class NotchInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public NotchInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public NotchInfo(NotchInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BuzaiID = vobjOther.BuzaiID;
                    this.Kind = vobjOther.Kind;
                    
                    foreach (NotchFig objNotchFig in vobjOther.Fig)
                    {
                        this.Fig.Add(new NotchFig(objNotchFig));
                    }
                }

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;

                /// <summary>
                /// 切り欠きID
                /// </summary>
                public int ID;

                /// <summary>
                /// 切欠き種類
                /// </summary>
                public enm.NotchKind Kind = enm.NotchKind.Undefined;

                /// <summary>
                /// 切り欠き図形
                /// </summary>
                public List<typ.NotchFig> Fig = new List<NotchFig>();
            }

            //-------------------------------------------------------------------------
            // Title   : 切り欠き図形
            // Date    : 2020/ 5/22
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 切り欠き図形
            /// </summary>
            public class NotchFig : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public NotchFig()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public NotchFig(NotchFig vobjOther)
                    : base ((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BuzaiID = vobjOther.BuzaiID;
                    this.NotchID = vobjOther.NotchID;
                    this.Figure2DKind = vobjOther.Figure2DKind;
                    this.Ps = vobjOther.Ps;
                    this.Pe = vobjOther.Pe;
                    this.Pc = vobjOther.Pc;
                    this.LPos = vobjOther.LPos;
                    this.SPos = vobjOther.SPos;
                    this.Direction = vobjOther.Direction;
                    this.R = vobjOther.R;
                }

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;

                /// <summary>
                /// 切り欠きID
                /// </summary>
                public int NotchID;

                /// <summary>
                /// ２Ｄ図形データ種類
                /// </summary>
                public enm.Figure2DKind Figure2DKind = enm.Figure2DKind.Undefined;

                /// <summary>
                /// 始点
                /// </summary>
                public zPMxCom.typ.Point3D Ps = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 終点
                /// </summary>
                public zPMxCom.typ.Point3D Pe = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 中点
                /// </summary>
                public zPMxCom.typ.Point3D Pc = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 長径
                /// </summary>
                public zPMxCom.typ.Point3D LPos = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 短径
                /// </summary>
                public zPMxCom.typ.Point3D SPos = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 円弧の向き
                /// </summary>
                public zPMxCom.typ.Arc.enm.ArcDirection Direction = zPMxCom.typ.Arc.enm.ArcDirection.Clockwise;

                /// <summary>
                /// 半径
                /// </summary>
                public double R = 0.0;
            }

            //-------------------------------------------------------------------------
            // Title   : 部材
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 部材
            /// </summary>
            public class Buzai : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Buzai()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Buzai(Buzai vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.Type = vobjOther.Type;
                    this.DataID = vobjOther.DataID;
                    this.PartsNo = vobjOther.PartsNo;
                    this.Code = vobjOther.Code;
                    this.Pair = vobjOther.Pair;
                    this.Kind = vobjOther.Kind;
                    this.PartsCount = vobjOther.PartsCount;
                    this.FloorID = vobjOther.FloorID;
                    this.Stanza = vobjOther.Stanza;
                    this.AreaID = vobjOther.AreaID;
                    this.NodeID = vobjOther.NodeID;
                    this.GroupID = vobjOther.GroupID;
                    this.PaintID = vobjOther.PaintID;
                    this.BuildID = vobjOther.BuildID;
                    this.ShipID = vobjOther.ShipID;
                    this.InpFace = vobjOther.InpFace;
                    this.InpFaceID = vobjOther.InpFaceID;
                    this.KeyplanID1 = vobjOther.KeyplanID1;
                    this.KeyplanID2 = vobjOther.KeyplanID2;
                    this.PanelID = vobjOther.PanelID;
                    this.PairID = vobjOther.PairID;
                    this.Name = vobjOther.Name;
                    this.Length = vobjOther.Length;
                    this.Expand = vobjOther.Expand;
                    this.Spread = vobjOther.Spread;
                    this.Material = new zPMxCom.typ.Material(vobjOther.Material);
                    this.CoordKind = vobjOther.CoordKind;

                    switch(this.CoordKind)
                    {
                        case enm.CoordKind.Straight:
                            {
                                this.Coord = new typ.Coord((typ.Coord)vobjOther.Coord);
                            }
                            break;

                        case enm.CoordKind.Arch:
                            {
                                this.Coord = new typ.CoordArch((typ.CoordArch)vobjOther.Coord);
                            }
                            break;
                    }

                    this.Set = vobjOther.Set;

                    if(vobjOther.Edge_LF != null)
                    {
                        this.Edge_LF = new EdgeInfo(vobjOther.Edge_LF);
                    }

                    if (vobjOther.Edge_RG != null)
                    {
                        this.Edge_RG = new EdgeInfo(vobjOther.Edge_RG);
                    }

                    foreach(typ.HoleInfo objHoleInfo in vobjOther.HoleInfo)
                    {
                        this.HoleInfo.Add(new typ.HoleInfo(objHoleInfo));
                    }

                    foreach(typ.ComponentInfo objComponentInfo in vobjOther.Components)
                    {
                        this.Components.Add(new ComponentInfo(objComponentInfo));
                    }

                    foreach(typ.NotchInfo objNotchInfo in vobjOther.NotchInfo)
                    {
                        this.NotchInfo.Add(new typ.NotchInfo(objNotchInfo));
                    }

                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 部材タイプ
                /// </summary>
                public enm.BuzaiType Type = enm.BuzaiType.Material;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 部材構成データ番号
                /// </summary>
                public int PartsNo;

                /// <summary>
                /// REAL4データ認識番号
                /// </summary>
                /// <remarks>
                /// 仕口単管時は下柱の認識番号。下柱がダミー部材の場合は上柱の認識番号
                /// </remarks>
                public long Code;

                /// <summary>
                /// 鋼材組み合わせ
                /// </summary>
                public enm.Pair Pair = enm.Pair.Single;

                /// <summary>
                /// 部材種類
                /// </summary>
                public zPMxCom.enm.BuzaiKind Kind = zPMxCom.enm.BuzaiKind.Undefined;

                /// <summary>
                /// 部材構成データ数
                /// </summary>
                public int PartsCount;

                /// <summary>
                /// 階高ID
                /// </summary>
                public int FloorID;

                /// <summary>
                /// 節
                /// </summary>
                public short Stanza;

                /// <summary>
                /// 工区ID
                /// </summary>
                public int AreaID;

                /// <summary>
                /// 分類ID
                /// </summary>
                public int NodeID;

                /// <summary>
                /// グループID
                /// </summary>
                public int GroupID;

                /// <summary>
                /// 塗装ID
                /// </summary>
                public int PaintID;

                /// <summary>
                /// 建方ID
                /// </summary>
                public int BuildID;

                /// <summary>
                /// 出荷ID
                /// </summary>
                public int ShipID;

                /// <summary>
                /// 入力面種類
                /// </summary>
                public enm.InpFace InpFace = enm.InpFace.Undefined;

                /// <summary>
                /// 入力面種類別ID
                /// </summary>
                /// <remarks>
                /// ・平面入力→階高ID
                /// ・側面入力→通りID
                /// ・母屋配置面入力→母屋配置面ID
                /// ・胴縁配置面入力→胴縁配置面ID
                /// </remarks>
                public int InpFaceID;

                /// <summary>
                /// キープランID1
                /// </summary>
                public int KeyplanID1;

                /// <summary>
                /// キープランID2
                /// </summary>
                public int KeyplanID2;

                /// <summary>
                /// パネルID
                /// </summary>
                /// <remarks>
                /// 母屋、胴縁
                /// </remarks>
                public int PanelID;

                /// <summary>
                /// 組ID
                /// </summary>
                /// <remarks>
                /// 本体、母屋、胴縁
                /// </remarks>
                public int PairID;

                /// <summary>
                /// 符号名
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 長さ
                /// </summary>
                public double Length;

                /// <summary>
                /// ちぢみ代
                /// </summary>
                public double Expand;

                /// <summary>
                /// 展開情報
                /// </summary>
                public enm.MaterialSpread Spread = enm.MaterialSpread.None;

                /// <summary>
                /// 部材構造
                /// </summary>
                public zPMxCom.typ.Material Material = new zPMxCom.typ.Material();

                /// <summary>
                /// ３Ｄデータ構造種類
                /// </summary>
                public enm.CoordKind CoordKind = enm.CoordKind.Straight;

                /// <summary>
                /// ３Ｄデータ構造
                /// </summary>
                public typ.ICoord Coord = null;

                /// <summary>
                /// 部材向き
                /// </summary>
                public enm.Set Set = enm.Set.VUL;

                /// <summary>
                /// 左端部情報
                /// </summary>
                public typ.EdgeInfo Edge_LF = new EdgeInfo();

                /// <summary>
                /// 右端部情報
                /// </summary>
                public typ.EdgeInfo Edge_RG = new EdgeInfo();

                /// <summary>
                /// 穴情報
                /// </summary>
                public List<typ.HoleInfo> HoleInfo = new List<HoleInfo>();

                /// <summary>
                /// 構成材料情報
                /// </summary>
                public List<typ.ComponentInfo> Components = new List<ComponentInfo>();

                /// <summary>
                /// 切欠き情報
                /// </summary>
                public List<typ.NotchInfo> NotchInfo = new List<NotchInfo>();

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //-Prop----------------------------------------------------------------
                //
                // 機能　　　: 参照
                //
                // 取得値　　: 重量
                //
                // 備考　　　: 2020/ 5/ 1 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 重量
                /// </summary>
                public double Mass
                {
                    get
                    {
                        double dblResult = 0.0;

                        switch(this.Material.Shape)
                        {
                            // PL
                            case zPMxCom.enm.Shape.PL:
                                {
                                    dblResult = (this.Material.UnitMass * ((this.Material.WH * this.Material.FH) / 1000000));
                                }
                                break;

                            default:
                                {
                                    dblResult = (this.Material.UnitMass * (this.Length + this.Expand));
                                }
                                break;
                        }

                        return dblResult;
                    }
                }

                //-Prop----------------------------------------------------------------
                //
                // 機能　　　: 参照
                //
                // 取得値　　: 面積
                //
                // 備考　　　: 2020/ 5/ 1 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 面積
                /// </summary>
                public double Area
                {
                    get
                    {
                        double dblResult = 0.0;

                        switch (this.Material.Shape)
                        {
                            // PL
                            case zPMxCom.enm.Shape.PL:
                                {
                                    dblResult = (this.Material.UnitArea * ((this.Material.WH * this.Material.FH) / 1000000));
                                }
                                break;

                            default:
                                {
                                    dblResult = (this.Material.UnitArea * (this.Length + this.Expand));
                                }
                                break;
                        }

                        return dblResult;
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolBuzai         - in 部材
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolBuzai">部材</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.Buzai> vcolBuzai)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("BuzaiData");
                            {
                                foreach (zPMxData.typ.Buzai objBuzai in vcolBuzai)
                                {
                                    objWriter.WriteStartElement("Buzai");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objBuzai.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objBuzai.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objBuzai.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objBuzai.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Type");
                                        {
                                            objWriter.WriteString(objBuzai.Type.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objBuzai.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PartsNo");
                                        {
                                            objWriter.WriteString(objBuzai.PartsNo.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objBuzai.Code.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Pair");
                                        {
                                            objWriter.WriteString(objBuzai.Pair.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Kind");
                                        {
                                            objWriter.WriteString(objBuzai.Kind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PartsCount");
                                        {
                                            objWriter.WriteString(objBuzai.PartsCount.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("FloorID");
                                        {
                                            objWriter.WriteString(objBuzai.FloorID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Stanza");
                                        {
                                            objWriter.WriteString(objBuzai.Stanza.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("AreaID");
                                        {
                                            objWriter.WriteString(objBuzai.AreaID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("NodeID");
                                        {
                                            objWriter.WriteString(objBuzai.NodeID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("GroupID");
                                        {
                                            objWriter.WriteString(objBuzai.GroupID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PaintID");
                                        {
                                            objWriter.WriteString(objBuzai.PaintID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("BuildID");
                                        {
                                            objWriter.WriteString(objBuzai.BuildID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ShipID");
                                        {
                                            objWriter.WriteString(objBuzai.ShipID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("InpFace");
                                        {
                                            objWriter.WriteString(objBuzai.InpFace.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("InpFaceID");
                                        {
                                            objWriter.WriteString(objBuzai.InpFaceID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KeyplanID1");
                                        {
                                            objWriter.WriteString(objBuzai.KeyplanID1.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KeyplanID2");
                                        {
                                            objWriter.WriteString(objBuzai.KeyplanID2.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PanelID");
                                        {
                                            objWriter.WriteString(objBuzai.PanelID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PairID");
                                        {
                                            objWriter.WriteString(objBuzai.PairID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objBuzai.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Length");
                                        {
                                            objWriter.WriteString(objBuzai.Length.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Expand");
                                        {
                                            objWriter.WriteString(objBuzai.Expand.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Spread");
                                        {
                                            objWriter.WriteString(objBuzai.Spread.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        msubWrite_Material(objWriter, objBuzai.Material);

                                        objWriter.WriteStartElement("CoordKind");
                                        {
                                            objWriter.WriteString(objBuzai.CoordKind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        switch (objBuzai.CoordKind)
                                        {
                                            case enm.CoordKind.Straight:
                                                {
                                                    var objCoord = (zPMxData.typ.Coord)objBuzai.Coord;

                                                    msubWrite_Coord(objWriter, objCoord);
                                                }
                                                break;

                                            case enm.CoordKind.Arch:
                                                {
                                                    var objCoordArch = (zPMxData.typ.CoordArch)objBuzai.Coord;

                                                    msubWrite_CoordArch(objWriter, objCoordArch);
                                                }
                                                break;
                                        }

                                        objWriter.WriteStartElement("Set");
                                        {
                                            objWriter.WriteString(objBuzai.Set.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        msubWrite_EdgeInfo(objWriter, "Edge_LF", objBuzai.Edge_LF);

                                        msubWrite_EdgeInfo(objWriter, "Edge_RG", objBuzai.Edge_RG);

                                        objWriter.WriteStartElement("HoleInfoData");
                                        {
                                            foreach (zPMxData.typ.HoleInfo objHoleInfo in objBuzai.HoleInfo)
                                            {
                                                msubWrite_HoleInfo(objWriter, objHoleInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Components");
                                        {
                                            foreach (zPMxData.typ.ComponentInfo objComponentInfo in objBuzai.Components)
                                            {
                                                msubWrite_ComponentInfo(objWriter, objComponentInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("NotchInfoData");
                                        {
                                            foreach (zPMxData.typ.NotchInfo objNotchInfo in objBuzai.NotchInfo)
                                            {
                                                msubWrite_NotchInfo(objWriter, objNotchInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objBuzai.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolBuzai         - out 部材
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolBuzai">部材</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.Buzai> rcolBuzai)
                {
                    rcolBuzai = new List<Buzai>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Buzai objBuzai = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Buzai":
                                        {
                                            objBuzai = new Buzai();
                                            rcolBuzai.Add(objBuzai);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objBuzai.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objBuzai.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objBuzai.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objBuzai.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Type":
                                        {
                                            objBuzai.Type = zPMxCom.Conv_StringToEnum<enm.BuzaiType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objBuzai.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "PartsNo":
                                        {
                                            objBuzai.PartsNo = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objBuzai.Code = objReader.ReadElementContentAsLong();
                                        }
                                        break;

                                    case "Pair":
                                        {
                                            objBuzai.Pair = zPMxCom.Conv_StringToEnum<enm.Pair>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Kind":
                                        {
                                            objBuzai.Kind = zPMxCom.Conv_StringToEnum<zPMxCom.enm.BuzaiKind>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "PartsCount":
                                        {
                                            objBuzai.PartsCount = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "FloorID":
                                        {
                                            objBuzai.FloorID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Stanza":
                                        {
                                            objBuzai.Stanza = (short)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "AreaID":
                                        {
                                            objBuzai.AreaID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "NodeID":
                                        {
                                            objBuzai.NodeID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "GroupID":
                                        {
                                            objBuzai.GroupID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "PaintID":
                                        {
                                            objBuzai.PaintID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "BuildID":
                                        {
                                            objBuzai.BuildID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ShipID":
                                        {
                                            objBuzai.ShipID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "InpFace":
                                        {
                                            objBuzai.InpFace = zPMxCom.Conv_StringToEnum<enm.InpFace>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "InpFaceID":
                                        {
                                            objBuzai.InpFaceID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KeyplanID1":
                                        {
                                            objBuzai.KeyplanID1 = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KeyplanID2":
                                        {
                                            objBuzai.KeyplanID2 = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "PanelID":
                                        {
                                            objBuzai.PanelID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "PairID":
                                        {
                                            objBuzai.PairID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objBuzai.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Length":
                                        {
                                            objBuzai.Length = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Expand":
                                        {
                                            objBuzai.Expand = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Spread":
                                        {
                                            objBuzai.Spread = zPMxCom.Conv_StringToEnum<enm.MaterialSpread>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Material":
                                        {
                                            msubRead_Material(objReader.ReadSubtree(), out objBuzai.Material);
                                        }
                                        break;

                                    case "CoordKind":
                                        {
                                            objBuzai.CoordKind = zPMxCom.Conv_StringToEnum<enm.CoordKind>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Coord":
                                        {
                                            typ.Coord objCoord;

                                            msubRead_Coord(objReader.ReadSubtree(), out objCoord);

                                            objBuzai.Coord = objCoord;
                                        }
                                        break;

                                    case "CoordArch":
                                        {
                                            typ.CoordArch objCoordArch;

                                            msubRead_CoordArch(objReader.ReadSubtree(), out objCoordArch);

                                            objBuzai.Coord = objCoordArch;
                                        }
                                        break;

                                    case "Set":
                                        {
                                            objBuzai.Set = zPMxCom.Conv_StringToEnum<enm.Set>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Edge_LF":
                                        {
                                            msubRead_EdgeInfo(objReader.ReadSubtree(), objReader.LocalName, out objBuzai.Edge_LF);
                                        }
                                        break;

                                    case "Edge_RG":
                                        {
                                            msubRead_EdgeInfo(objReader.ReadSubtree(), objReader.LocalName, out objBuzai.Edge_RG);
                                        }
                                        break;

                                    case "HoleInfoData":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_HoleInfoData(objReader.ReadSubtree(), ref objBuzai.HoleInfo);
                                            }
                                        }
                                        break;

                                    case "Components":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_Components(objReader.ReadSubtree(), ref objBuzai.Components);
                                            }
                                        }
                                        break;

                                    case "NotchInfoData":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_NotchInfoData(objReader.ReadSubtree(), ref objBuzai.NotchInfo);
                                            }
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objBuzai.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 端部情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 端部情報
            /// </summary>
            public class EdgeInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public EdgeInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public EdgeInfo(EdgeInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BuzaiID = vobjOther.BuzaiID;
                    this.ID = vobjOther.ID;
                    this.Type = vobjOther.Type;
                    this.ConnectKind = vobjOther.ConnectKind;
                    this.ConnectID = vobjOther.ConnectID;
                    this.ConnectDataID = vobjOther.ConnectDataID;
                    this.JointName = vobjOther.JointName;
                    this.Edge_DataID = vobjOther.Edge_DataID;
                    this.Edge_BuhinID = vobjOther.Edge_BuhinID;
                    
                    foreach (typ.EdgeScallopInfo objEdgeScallopInfo in vobjOther.ScallopInfo)
                    {
                        this.ScallopInfo.Add(new EdgeScallopInfo(objEdgeScallopInfo));
                    }

                    foreach (typ.EdgeWeldGroInfo objEdgeWeldGroInfo in vobjOther.WeldGroInfo)
                    {
                        this.WeldGroInfo.Add(new EdgeWeldGroInfo(objEdgeWeldGroInfo));
                    }

                    this.WeldLen = vobjOther.WeldLen;
                }

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;

                /// <summary>
                /// ID
                /// </summary>
                /// <remarks>左端部＝1、右端部＝2</remarks>
                public int ID;

                /// <summary>
                /// 端部タイプ
                /// </summary>
                public enm.EdgeType Type = enm.EdgeType.None;

                /// <summary>
                /// 端部接続先種類
                /// </summary>
                public enm.EdgeConnectKind ConnectKind = enm.EdgeConnectKind.None;

                /// <summary>
                /// 端部接続先ID
                /// </summary>
                /// <remarks>
                /// 生産管理システムの鋼材IDor仕口ID
                /// 端部接続先種類＝なしの場合は0
                /// </remarks>
                public int ConnectID;

                /// <summary>
                /// 端部接続先データID
                /// </summary>
                /// <remarks>
                /// REAL4の施工図データID
                /// </remarks>
                public int ConnectDataID;

                /// <summary>
                /// 端部接続先構成データ番号
                /// </summary>
                /// <remarks>
                /// REAL4の施工図構成データ番号
                /// </remarks>
                public int ConnectPartsNo;

                /// <summary>
                /// 継手名
                /// </summary>
                public string JointName = "";

                /// <summary>
                /// 端部材ID
                /// </summary>
                public int Edge_DataID;

                /// <summary>
                /// 端部材部品ID
                /// </summary>
                public int Edge_BuhinID;

                /// <summary>
                /// スカラップ情報
                /// </summary>
                public List<typ.EdgeScallopInfo> ScallopInfo = new List<EdgeScallopInfo>();

                /// <summary>
                /// 開先情報
                /// </summary>
                public List<typ.EdgeWeldGroInfo> WeldGroInfo = new List<EdgeWeldGroInfo>();

                /// <summary>
                /// 溶接長
                /// </summary>
                public double WeldLen;
            }

            //-------------------------------------------------------------------------
            // Title   : スカラップ情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// スカラップ情報
            /// </summary>
            public class EdgeScallopInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public EdgeScallopInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public EdgeScallopInfo(EdgeScallopInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BuzaiID = vobjOther.BuzaiID;
                    this.SubID = vobjOther.SubID;
                    this.Kind = vobjOther.Kind;
                }

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;

                /// <summary>
                /// サブID
                /// </summary>
                public int SubID;

                /// <summary>
                /// スカラップ種類
                /// </summary>
                public zPMxCom.enm.WeldScallopKind Kind = zPMxCom.enm.WeldScallopKind.None;
            }

            //-------------------------------------------------------------------------
            // Title   : 端部開先情報
            // Date    : 2020/ 5/20
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 端部開先情報
            /// </summary>
            public class EdgeWeldGroInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/20 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public EdgeWeldGroInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/20 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public EdgeWeldGroInfo(EdgeWeldGroInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BuzaiID = vobjOther.BuzaiID;
                    this.SubID = vobjOther.SubID;
                    this.TipKind = vobjOther.TipKind;
                    this.WeldAngle1 = vobjOther.WeldAngle1;
                    this.WeldAngle2 = vobjOther.WeldAngle2;
                    this.WeldDepth1 = vobjOther.WeldDepth1;
                    this.WeldDepth2 = vobjOther.WeldDepth2;
                    this.RG = vobjOther.RG;
                }

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;

                /// <summary>
                /// サブID
                /// </summary>
                public int SubID;

                /// <summary>
                /// 開先形状
                /// </summary>
                public zPMxCom.enm.Weld.TipKind TipKind = zPMxCom.enm.Weld.TipKind.Undefined;

                /// <summary>
                /// 開先角度1
                /// </summary>
                public double WeldAngle1;

                /// <summary>
                /// 開先角度2
                /// </summary>
                public double WeldAngle2;

                /// <summary>
                /// 開先深さ1
                /// </summary>
                public double WeldDepth1;

                /// <summary>
                /// 開先深さ2
                /// </summary>
                public double WeldDepth2;

                /// <summary>
                /// ルートギャップ
                /// </summary>
                public double RG;
            }

            //-------------------------------------------------------------------------
            // Title   : 穴情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 穴情報
            /// </summary>
            public class HoleInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 4/28 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public HoleInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOterh - in コピー元
                //
                // 備考　　　: 2020/ 4/28 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOterh">コピー元</param>
                public HoleInfo(HoleInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BuzaiID = vobjOther.BuzaiID;
                    this.Kind = vobjOther.Kind;
                    this.Shape = vobjOther.Shape;
                    this.FaceNo = vobjOther.FaceNo;
                    this.Pos = vobjOther.Pos;
                    this.Vector = vobjOther.Vector;
                    this.Dia = vobjOther.Dia;
                    this.Width = vobjOther.Width;
                    this.TiltVector = vobjOther.TiltVector;
                    this.SleeveKind = vobjOther.SleeveKind;
                    this.BoltID = vobjOther.BoltID;
                    this.BoltDia = vobjOther.BoltDia;
                    this.BoltLength = vobjOther.BoltLength;
                    this.AnchorBoltKind = vobjOther.AnchorBoltKind;
                    this.AnchorBoltStd = vobjOther.AnchorBoltStd;
                }

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;

                /// <summary>
                /// 穴種類
                /// </summary>
                public enm.HoleKind Kind = enm.HoleKind.Normal;

                /// <summary>
                /// 形状
                /// </summary>
                public enm.HoleShape Shape = enm.HoleShape.Circle;

                /// <summary>
                /// 面番号
                /// </summary>
                public byte FaceNo;

                /// <summary>
                /// 穴座標
                /// </summary>
                public zPMxCom.typ.Point3D Pos = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 穴の向きを示す単位ベクトル
                /// </summary>
                public zPMxCom.typ.Point3D Vector = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 穴径
                /// </summary>
                public double Dia;

                /// <summary>
                /// 幅
                /// </summary>
                public double Width;

                /// <summary>
                /// 穴の傾きを示す単位ベクトル
                /// </summary>
                public zPMxCom.typ.Point3D TiltVector = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// スリーブ種類
                /// </summary>
                public enm.SleeveKind SleeveKind = enm.SleeveKind.Undefined;

                /// <summary>
                /// ボルトID
                /// </summary>
                public int BoltID;

                /// <summary>
                /// ボルト径
                /// </summary>
                public double BoltDia;

                /// <summary>
                /// ボルト首下長さ
                /// </summary>
                public double BoltLength;

                /// <summary>
                /// アンカーボルト材種ID
                /// </summary>
                public int AnchorBoltKind;

                /// <summary>
                /// アンカーボルト材質
                /// </summary>
                public int AnchorBoltStd;
            }

            //-------------------------------------------------------------------------
            // Title   : 構成材料情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 構成材料情報
            /// </summary>
            public class ComponentInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ComponentInfo()
                {}

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ComponentInfo(ComponentInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.BaseKind = vobjOther.BaseKind;
                    this.BaseID = vobjOther.BaseID;
                    this.ID = vobjOther.ID;
                    this.Kind = vobjOther.Kind;

                    switch(this.Kind)
                    {
                        case enm.ComponentKind.Buzai:
                            {
                                this.ConInfo = new typ.ConInfoBuzai((typ.ConInfoBuzai)vobjOther.ConInfo);
                            }
                            break;

                        case enm.ComponentKind.Kataita:
                            {
                                this.ConInfo = new typ.ConInfoKataita((typ.ConInfoKataita)vobjOther.ConInfo);
                            }
                            break;

                        case enm.ComponentKind.Buhin:
                            {
                                this.ConInfo = new typ.ConInfoBuhin((typ.ConInfoBuhin)vobjOther.ConInfo);
                            }
                            break;
                    }
                }

                /// <summary>
                /// 親データ種類
                /// </summary>
                public enm.ComponentBaseKind BaseKind = enm.ComponentBaseKind.Buzai;

                /// <summary>
                /// 親データID
                /// </summary>
                public int BaseID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 構成材料種類
                /// </summary>
                public enm.ComponentKind Kind = enm.ComponentKind.Undefined;

                /// <summary>
                /// 接続情報
                /// </summary>
                public IConInfo ConInfo = null;
            }

            //-------------------------------------------------------------------------
            // Title   : 接続情報インターフェース
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 接続情報インターフェース
            /// </summary>
            public interface IConInfo
            { }

            //-------------------------------------------------------------------------
            // Title   : 部材接続情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 部材接続情報
            /// </summary>
            public class ConInfoBuzai : IConInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ConInfoBuzai()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ConInfoBuzai(ConInfoBuzai vobjOther)
                {
                    this.BuzaiID = vobjOther.BuzaiID;
                    this.Type = vobjOther.Type;
                    this.DataID = vobjOther.DataID;
                    this.PartsNo = vobjOther.PartsNo;
                    this.Code = vobjOther.Code;

                    foreach(typ.WeldInfo objWeldInfo in vobjOther.WeldInfo)
                    {
                        this.WeldInfo.Add(new typ.WeldInfo(objWeldInfo));
                    }
                }

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;

                /// <summary>
                /// 部材タイプ
                /// </summary>
                public enm.BuzaiType Type = enm.BuzaiType.Material;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 部材構成データ番号
                /// </summary>
                public int PartsNo;

                /// <summary>
                /// REAL4データ認識番号
                /// </summary>
                public long Code;

                /// <summary>
                /// 溶接情報
                /// </summary>
                public List<typ.WeldInfo> WeldInfo = new List<WeldInfo>();
            }

            //-------------------------------------------------------------------------
            // Title   : 部品接続情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 部品接続情報
            /// </summary>
            public class ConInfoBuhin : IConInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ConInfoBuhin()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ConInfoBuhin(ConInfoBuhin vobjOther)
                {
                    this.BuhinID = vobjOther.BuhinID;

                    foreach (typ.WeldInfo objWeldInfo in vobjOther.WeldInfo)
                    {
                        this.WeldInfo.Add(new typ.WeldInfo(objWeldInfo));
                    }

                    this.CoordKind = vobjOther.CoordKind;

                    if (vobjOther.Coord != null)
                    {
                        switch (this.CoordKind)
                        {
                            case enm.CoordKind.Straight:
                                {
                                    this.Coord = new typ.Coord((typ.Coord)vobjOther.Coord);
                                }
                                break;

                            case enm.CoordKind.Arch:
                                {


                                    this.Coord = new typ.CoordArch((typ.CoordArch)vobjOther.Coord);
                                }
                                break;
                        }
                    }
                }

                /// <summary>
                /// 部品ID
                /// </summary>
                public int BuhinID;

                /// <summary>
                /// 溶接情報
                /// </summary>
                public List<typ.WeldInfo> WeldInfo = new List<WeldInfo>();

                /// <summary>
                /// ３Ｄデータ構造種類
                /// </summary>
                public enm.CoordKind CoordKind = enm.CoordKind.Straight;

                /// <summary>
                /// ３Ｄデータ構造
                /// </summary>
                public typ.ICoord Coord = null;
            }

            //-------------------------------------------------------------------------
            // Title   : 板接続情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 板接続情報
            /// </summary>
            public class ConInfoKataita : IConInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ConInfoKataita()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ConInfoKataita(ConInfoKataita vobjOther)
                {
                    this.KataitaID = vobjOther.KataitaID;

                    foreach (typ.KataitaParts objKataitaParts in vobjOther.Parts)
                    {
                        this.Parts.Add(new KataitaParts(objKataitaParts));
                    }
                }

                /// <summary>
                /// 型板ID
                /// </summary>
                public int KataitaID;

                /// <summary>
                /// 板辺接続情報
                /// </summary>
                public List<typ.KataitaParts> Parts = new List<KataitaParts>();
            }

            //-------------------------------------------------------------------------
            // Title   : 板構成データ接続情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 板構成データ接続情報
            /// </summary>
            public class KataitaParts : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public KataitaParts()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public KataitaParts(KataitaParts vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.Pos3D[0] = vobjOther.Pos3D[0];
                    this.Pos3D[1] = vobjOther.Pos3D[1];
                    this.Pos3D[2] = vobjOther.Pos3D[2];

                    foreach(typ.KataitaSideInfo objKataitaSideInfo in vobjOther.SideInfo)
                    {
                        this.SideInfo.Add(new KataitaSideInfo(objKataitaSideInfo));
                    }
                }

                /// <summary>
                /// 構成材料情報ID
                /// </summary>
                public int CompID;

                /// <summary>
                /// ３Ｄ上の位置を示す点（３点）
                /// </summary>
                /// <remarks>
                /// インデックス０は、２Ｄ図形上の原点を示すポイント
                /// インデックス１は、２Ｄ図形上のX軸のプラス側を示すポイント
                /// インデックス２は、２Ｄ図形上のY軸のプラス側を示すポイント
                /// </remarks>
                public zPMxCom.typ.Point3D[] Pos3D = new zPMxCom.typ.Point3D[3];

                /// <summary>
                /// 板辺接続情報
                /// </summary>
                public List<typ.KataitaSideInfo> SideInfo = new List<KataitaSideInfo>();
            }

            //-------------------------------------------------------------------------
            // Title   : 板辺接続情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 板辺接続情報
            /// </summary>
            public class KataitaSideInfo : zPMxCom.typ.BaseInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public KataitaSideInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public KataitaSideInfo(KataitaSideInfo vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.KataitaID = vobjOther.KataitaID;
                    this.ConInfoID = vobjOther.ConInfoID;
                    this.PartsID = vobjOther.PartsID;
                    this.ID = vobjOther.ID;
                    this.ConLine = new zPMxCom.typ.Line3D(vobjOther.ConLine);
                    this.Vector = vobjOther.Vector;
                    this.FaceNo = vobjOther.FaceNo;
                    this.FaceEx = vobjOther.FaceEx;
                    this.WeldInfo = new WeldInfo(vobjOther.WeldInfo);
                }

                /// <summary>
                /// 型板ID
                /// </summary>
                public int KataitaID;

                /// <summary>
                /// 板接続情報ID
                /// </summary>
                public int ConInfoID;

                /// <summary>
                /// 板構成データID
                /// </summary>
                public int PartsID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 接続輪郭線
                /// </summary>
                /// <remarks>
                /// 円弧の場合もzPMx_3DLineで始終点を保持
                /// </remarks>
                public zPMxCom.typ.Line3D ConLine = new zPMxCom.typ.Line3D();

                /// <summary>
                /// 接続面の法線ベクトル
                /// </summary>
                public zPMxCom.typ.Point3D Vector = zPMxCom.typ.Point3D.Zero;

                /// <summary>
                /// 面番号
                /// </summary>
                public byte FaceNo;

                /// <summary>
                /// 拡張面番号
                /// </summary>
                public byte FaceEx;

                /// <summary>
                /// 溶接情報
                /// </summary>
                public typ.WeldInfo WeldInfo = new WeldInfo();
            }

            //-------------------------------------------------------------------------
            // Title   : 型板情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 型板情報
            /// </summary>
            public class Kataita : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Kataita()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Kataita(Kataita vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.Name = vobjOther.Name;
                    this.Type = vobjOther.Type;
                    this.Kind = vobjOther.Kind;
                    this.Std = vobjOther.Std;
                    this.Thick = vobjOther.Thick;
                    this.Remarks = vobjOther.Remarks;
                    this.PatShapeID = vobjOther.PatShapeID;
                    this.Height = vobjOther.Height;
                    this.Width = vobjOther.Width;
                    this.Count = vobjOther.Count;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 内容比較（※IDや枚数は比較していません）
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝同じ、偽＝異なる
                //
                // 備考　　　: 2020/ 5/21 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 内容比較（※IDや枚数は比較していません）
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝同じ、偽＝異なる</returns>
                public bool Comp(typ.Kataita vobjOther)
                {
                    if (this.Name == vobjOther.Name &&
                        this.Type == vobjOther.Type &&
                        this.Kind == vobjOther.Kind &&
                        this.Std == vobjOther.Std &&
                        this.Thick == vobjOther.Thick &&
                        this.Remarks == vobjOther.Remarks &&
                        this.PatShapeID == vobjOther.PatShapeID &&
                        this.Height == vobjOther.Height &&
                        this.Width == vobjOther.Width)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// 型板ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 型紙図番
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 型板種類
                /// </summary>
                public enm.ComponentType Type = enm.ComponentType.Undefined;

                /// <summary>
                /// 材種ID
                /// </summary>
                public int Kind;

                /// <summary>
                /// 材質
                /// </summary>
                public int Std;

                /// <summary>
                /// 板厚
                /// </summary>
                public double Thick;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                /// <summary>
                /// 型紙形状ID
                /// </summary>
                public int PatShapeID;

                /// <summary>
                /// 高さ
                /// </summary>
                public double Height;

                /// <summary>
                /// 幅
                /// </summary>
                public double Width;

                /// <summary>
                /// 枚数
                /// </summary>
                public int Count;

                // TODO: 形状が必要な場合は変数が必要

                //---------------------------------------------------------------------
                //
                // 機能　　　: 型板情報のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolKataita       - in 型板情報
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 型板情報のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolKataita">型板情報</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.Kataita> vcolKataita)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("KataitaData");
                            {
                                foreach (zPMxData.typ.Kataita objKataita in vcolKataita)
                                {
                                    objWriter.WriteStartElement("Kataita");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objKataita.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objKataita.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objKataita.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objKataita.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objKataita.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Type");
                                        {
                                            objWriter.WriteString(objKataita.Type.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Kind");
                                        {
                                            objWriter.WriteString(objKataita.Kind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Std");
                                        {
                                            objWriter.WriteString(objKataita.Std.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Thick");
                                        {
                                            objWriter.WriteString(objKataita.Thick.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objKataita.Remarks);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PatShapeID");
                                        {
                                            objWriter.WriteString(objKataita.PatShapeID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Height");
                                        {
                                            objWriter.WriteString(objKataita.Height.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Width");
                                        {
                                            objWriter.WriteString(objKataita.Width.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Count");
                                        {
                                            objWriter.WriteString(objKataita.Count.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 型板のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolKataita       - out 型板
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 型板のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolKataita">型板</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.Kataita> rcolKataita)
                {
                    rcolKataita = new List<Kataita>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Kataita objKataita = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Kataita":
                                        {
                                            objKataita = new Kataita();
                                            rcolKataita.Add(objKataita);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objKataita.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objKataita.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objKataita.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objKataita.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objKataita.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Type":
                                        {
                                            objKataita.Type = zPMxCom.Conv_StringToEnum<enm.ComponentType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Kind":
                                        {
                                            objKataita.Kind = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Std":
                                        {
                                            objKataita.Std = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Thick":
                                        {
                                            objKataita.Thick = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objKataita.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "PatShapeID":
                                        {
                                            objKataita.PatShapeID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Height":
                                        {
                                            objKataita.Height = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Width":
                                        {
                                            objKataita.Width = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Count":
                                        {
                                            objKataita.Count = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 部品情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 部品情報
            /// </summary>
            public class Buhin : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Buhin()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Buhin(Buhin vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.Type = vobjOther.Type;
                    this.Name = vobjOther.Name;
                    this.MstName = vobjOther.MstName;
                    this.Material = new zPMxCom.typ.Material(vobjOther.Material);
                    this.Set = vobjOther.Set;
                    this.Count = vobjOther.Count;
                    this.PartsShapeID = vobjOther.PartsShapeID;

                    if (vobjOther.Coord != null)
                    {
                        this.Coord = new Coord(vobjOther.Coord);
                    }

                    this.Remarks = vobjOther.Remarks;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 内容比較（※IDや個数、Coordは比較していません）
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝同じ、偽＝異なる
                //
                // 備考　　　: 2020/ 5/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 内容比較（※IDや個数、Coordは比較していません）
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝同じ、偽＝異なる</returns>
                public bool Comp(typ.Buhin vobjOther)
                {
                    if (this.Type == vobjOther.Type &&
                        this.Name == vobjOther.Name &&
                        this.R4MstKind == vobjOther.R4MstKind &&
                        this.MstName == vobjOther.MstName &&
                        this.Material.Equals(vobjOther.Material) &&
                        this.PartsShapeID == vobjOther.PartsShapeID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 部品種類
                /// </summary>
                public enm.ComponentType Type = enm.ComponentType.Undefined;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// REAL4マスター種類
                /// </summary>
                public zPMxCom.enm.R4MstKind R4MstKind = zPMxCom.enm.R4MstKind.None;

                /// <summary>
                /// 部材名
                /// </summary>
                public string MstName = "";

                /// <summary>
                /// 部材構造
                /// </summary>
                public zPMxCom.typ.Material Material = new zPMxCom.typ.Material();

                /// <summary>
                /// 部材向き
                /// </summary>
                public enm.Set Set = enm.Set.VUL;

                /// <summary>
                /// 個数
                /// </summary>
                public int Count;

                /// <summary>
                /// 部品形状ID
                /// </summary>
                public int PartsShapeID;

                /// <summary>
                /// ３Ｄ構造
                /// </summary>
                public typ.Coord Coord = null;

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: 部品情報のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolBuhin         - in 部品情報
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 部品情報のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolBuhin">部品情報</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.Buhin> vcolBuhin)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("BuhinData");
                            {
                                foreach (zPMxData.typ.Buhin objBuhin in vcolBuhin)
                                {
                                    objWriter.WriteStartElement("Buhin");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objBuhin.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objBuhin.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objBuhin.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objBuhin.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Type");
                                        {
                                            objWriter.WriteString(objBuhin.Type.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objBuhin.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("R4MstKind");
                                        {
                                            objWriter.WriteString(objBuhin.R4MstKind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("MstName");
                                        {
                                            objWriter.WriteString(objBuhin.MstName);
                                        }
                                        objWriter.WriteEndElement();

                                        msubWrite_Material(objWriter, objBuhin.Material);

                                        objWriter.WriteStartElement("Set");
                                        {
                                            objWriter.WriteString(objBuhin.Set.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Count");
                                        {
                                            objWriter.WriteString(objBuhin.Count.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PartsShapeID");
                                        {
                                            objWriter.WriteString(objBuhin.PartsShapeID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        if (objBuhin.Coord != null)
                                        {
                                            msubWrite_Coord(objWriter, objBuhin.Coord);
                                        }

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objBuhin.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 部品のXML読み込み
                //
                // 引き数　　: vstrFilePath  - in ファイルパス
                // 　　　　　: rcolBuhin     - out 部品
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 部品のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolBuhin">部品</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.Buhin> rcolBuhin)
                {
                    rcolBuhin = new List<Buhin>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Buhin objBuhin = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Buhin":
                                        {
                                            objBuhin = new Buhin();
                                            rcolBuhin.Add(objBuhin);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objBuhin.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objBuhin.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objBuhin.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objBuhin.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Type":
                                        {
                                            objBuhin.Type = zPMxCom.Conv_StringToEnum<enm.ComponentType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objBuhin.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "R4MstKind":
                                        {
                                            objBuhin.R4MstKind = zPMxCom.Conv_StringToEnum<zPMxCom.enm.R4MstKind>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "MstName":
                                        {
                                            objBuhin.MstName = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Material":
                                        {
                                            msubRead_Material(objReader.ReadSubtree(), out objBuhin.Material);
                                        }
                                        break;

                                    case "Set":
                                        {
                                            objBuhin.Set = zPMxCom.Conv_StringToEnum<enm.Set>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Count":
                                        {
                                            objBuhin.Count = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "PartsShapeID":
                                        {
                                            objBuhin.PartsShapeID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Coord":
                                        {
                                            msubRead_Coord(objReader.ReadSubtree(), out objBuhin.Coord);
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objBuhin.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //---------------------------------------------------------------------
            //
            // 機能　　　: 部材構造のXML書き出し
            //
            // 引き数　　: vobjWriter        - in XmlWriter
            // 　　　　　: vobjMaterial      - in 部材構造
            //
            // 備考　　　: 2020/ 6/16 - 金子　淳哉
            //
            //---------------------------------------------------------------------
            /// <summary>
            /// 部材構造のXML書き出し
            /// </summary>
            /// <param name="vobjWriter">XmlWriter</param>
            /// <param name="vobjMaterial">部材構造</param>
            private static void msubWrite_Material(XmlWriter vobjWriter, zPMxCom.typ.Material vobjMaterial)
            {
                vobjWriter.WriteStartElement("Material");
                {
                    vobjWriter.WriteStartElement("Kind");
                    {
                        vobjWriter.WriteString(vobjMaterial.Kind.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("Shape");
                    {
                        vobjWriter.WriteString(vobjMaterial.Shape.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("WH");
                    {
                        vobjWriter.WriteString(vobjMaterial.WH.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("FH");
                    {
                        vobjWriter.WriteString(vobjMaterial.FH.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("WT");
                    {
                        vobjWriter.WriteString(vobjMaterial.WT.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("FT");
                    {
                        vobjWriter.WriteString(vobjMaterial.FT.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("Size");
                    {
                        vobjWriter.WriteString(vobjMaterial.Size);
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("StdF");
                    {
                        vobjWriter.WriteString(vobjMaterial.StdF.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("StdW");
                    {
                        vobjWriter.WriteString(vobjMaterial.StdW.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("R1");
                    {
                        vobjWriter.WriteString(vobjMaterial.R1.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("R2");
                    {
                        vobjWriter.WriteString(vobjMaterial.R2.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("R3");
                    {
                        vobjWriter.WriteString(vobjMaterial.R3.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("UnitMass");
                    {
                        vobjWriter.WriteString(vobjMaterial.UnitMass.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("UnitArea");
                    {
                        vobjWriter.WriteString(vobjMaterial.UnitArea.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("Seam");
                    {
                        vobjWriter.WriteString(vobjMaterial.Seam.ToString());
                    }
                    vobjWriter.WriteEndElement();
                }
                vobjWriter.WriteEndElement();
            }

            //-------------------------------------------------------------------------
            // Title   : 仕口情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 仕口情報
            /// </summary>
            public class Shiguchi : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 仕口名称
                /// </summary>
                public string ShiguchiName = "";

                /// <summary>
                /// コア名称
                /// </summary>
                public string CoreName = "";

                /// <summary>
                /// 構成材料情報
                /// </summary>
                public List<typ.ComponentInfo> Components = new List<ComponentInfo>();

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Shiguchi()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Shiguchi(Shiguchi vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.ShiguchiName = vobjOther.ShiguchiName;
                    this.CoreName = vobjOther.CoreName;

                    foreach (typ.ComponentInfo objComponentInfo in vobjOther.Components)
                    {
                        this.Components.Add(new ComponentInfo(objComponentInfo));
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 仕口情報のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolShiguchi      - in 仕口情報
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 仕口情報のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolShiguchi">仕口情報</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.Shiguchi> vcolShiguchi)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("ShiguchiData");
                            {
                                foreach (zPMxData.typ.Shiguchi objShiguchi in vcolShiguchi)
                                {
                                    objWriter.WriteStartElement("Shiguchi");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objShiguchi.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objShiguchi.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objShiguchi.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objShiguchi.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objShiguchi.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ShiguchiName");
                                        {
                                            objWriter.WriteString(objShiguchi.ShiguchiName);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CoreName");
                                        {
                                            objWriter.WriteString(objShiguchi.CoreName);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Components");
                                        {
                                            foreach (zPMxData.typ.ComponentInfo objComponentInfo in objShiguchi.Components)
                                            {
                                                msubWrite_ComponentInfo(objWriter, objComponentInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 仕口のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolShiguchi      - out 仕口
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 仕口のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolShiguchi">仕口</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.Shiguchi> rcolShiguchi)
                {
                    rcolShiguchi = new List<Shiguchi>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Shiguchi objShiguchi = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Shiguchi":
                                        {
                                            objShiguchi = new Shiguchi();
                                            rcolShiguchi.Add(objShiguchi);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objShiguchi.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objShiguchi.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objShiguchi.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objShiguchi.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objShiguchi.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ShiguchiName":
                                        {
                                            objShiguchi.ShiguchiName = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "CoreName":
                                        {
                                            objShiguchi.CoreName = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Components":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_Components(objReader.ReadSubtree(), ref objShiguchi.Components);
                                            }
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 製品情報
            // Date    : 2020/ 4/21
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 製品情報
            /// </summary>
            public class Seihin : zPMxCom.typ.BaseInfo, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Seihin()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 7 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Seihin(Seihin vobjOther)
                    : base((zPMxCom.typ.BaseInfo)vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.DataID = vobjOther.DataID;
                    this.MainComponent = new ComponentInfo(vobjOther.MainComponent);

                    foreach(typ.ComponentInfo objComponentInfo in vobjOther.SubComponents)
                    {
                        this.SubComponents.Add(new ComponentInfo(objComponentInfo));
                    }

                    this.ShiguchiID.AddRange(vobjOther.ShiguchiID);
                    this.CoreDataID.AddRange(vobjOther.CoreDataID);
                    this.Name = vobjOther.Name;
                    this.Length = vobjOther.Length;
                }

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 施工図データID
                /// </summary>
                public int DataID;

                /// <summary>
                /// 代表部材の材料情報
                /// </summary>
                public typ.ComponentInfo MainComponent = null;

                /// <summary>
                /// 構成材料情報
                /// </summary>
                /// <remarks>
                /// ※代表部材の情報は含まない
                /// </remarks>
                public List<typ.ComponentInfo> SubComponents = new List<ComponentInfo>();

                /// <summary>
                /// 仕口ID
                /// </summary>
                public List<int> ShiguchiID = new List<int>();

                /// <summary>
                /// コアID
                /// </summary>
                public List<int> CoreDataID = new List<int>();

                /// <summary>
                /// 製品名
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 長さ
                /// </summary>
                public double Length;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 製品情報のXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolSeihin        - in 製品情報
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 製品情報のXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolSeihin">製品情報</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.Seihin> vcolSeihin)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("SeihinData");
                            {
                                foreach (zPMxData.typ.Seihin objSeihin in vcolSeihin)
                                {
                                    objWriter.WriteStartElement("Seihin");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objSeihin.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KoujiID");
                                        {
                                            objWriter.WriteString(objSeihin.KoujiID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objSeihin.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objSeihin.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DataID");
                                        {
                                            objWriter.WriteString(objSeihin.DataID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        if (objSeihin.MainComponent != null)
                                        {
                                            objWriter.WriteStartElement("MainComponent");
                                            {
                                                msubWrite_ComponentInfo(objWriter, objSeihin.MainComponent);
                                            }
                                            objWriter.WriteEndElement();
                                        }

                                        objWriter.WriteStartElement("SubComponents");
                                        {
                                            foreach (zPMxData.typ.ComponentInfo objComponentInfo in objSeihin.SubComponents)
                                            {
                                                msubWrite_ComponentInfo(objWriter, objComponentInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ShiguchiIDData");
                                        {
                                            foreach (int intShiguchiID in objSeihin.ShiguchiID)
                                            {
                                                objWriter.WriteStartElement("ShiguchiID");
                                                {
                                                    objWriter.WriteString(intShiguchiID.ToString());
                                                }
                                                objWriter.WriteEndElement();
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CoreDataIDData");
                                        {
                                            foreach (int intCoreDataID in objSeihin.CoreDataID)
                                            {
                                                objWriter.WriteStartElement("CoreDataID");
                                                {
                                                    objWriter.WriteString(intCoreDataID.ToString());
                                                }
                                                objWriter.WriteEndElement();
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objSeihin.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Length");
                                        {
                                            objWriter.WriteString(objSeihin.Length.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 製品のXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolSeihin        - out 製品
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 製品のXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolSeihin">製品</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.Seihin> rcolSeihin)
                {
                    rcolSeihin = new List<Seihin>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.Seihin objSeihin = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Seihin":
                                        {
                                            objSeihin = new Seihin();
                                            rcolSeihin.Add(objSeihin);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objSeihin.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "KoujiID":
                                        {
                                            objSeihin.KoujiID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objSeihin.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objSeihin.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DataID":
                                        {
                                            objSeihin.DataID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "MainComponent":
                                        {
                                            msubRead_Component(objReader.ReadSubtree(), out objSeihin.MainComponent);
                                        }
                                        break;

                                    case "SubComponents":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_Components(objReader.ReadSubtree(), ref objSeihin.SubComponents);
                                            }
                                        }
                                        break;

                                    case "ShiguchiIDData":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                zPMxCom.Read_ListInt(objReader.ReadSubtree(), "ShiguchiID", ref objSeihin.ShiguchiID);
                                            }
                                        }
                                        break;

                                    case "CoreDataIDData":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                zPMxCom.Read_ListInt(objReader.ReadSubtree(), "CoreDataID", ref objSeihin.CoreDataID);
                                            }
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objSeihin.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Length":
                                        {
                                            objSeihin.Length = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 製作グループ
            // Date    : 2020/ 4/28
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 製作グループ
            /// </summary>
            public class WorkGroup : IEquatable<WorkGroup>, zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public WorkGroup()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WorkGroup(WorkGroup vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.ID = vobjOther.ID;
                    this.Level = vobjOther.Level;
                    this.ParentID = vobjOther.ParentID;
                    
                    foreach (WorkGroupSeihinInfo objWorkGroupSeihinInfo in vobjOther.SeihinInfo)
                    {
                        this.SeihinInfo.Add(new WorkGroupSeihinInfo(objWorkGroupSeihinInfo));
                    }

                    this.WorkProcessID = vobjOther.WorkProcessID;
                    this.CompleteDate = vobjOther.CompleteDate;
                    this.WorkOrder = vobjOther.WorkOrder;
                    
                    foreach (WorkGroupNameInfo objWorkGroupNameInfo in vobjOther.NameInfo)
                    {
                        this.NameInfo.Add(new WorkGroupNameInfo(objWorkGroupNameInfo));
                    }

                    this.Remarks = vobjOther.Remarks;
                    this.Color = vobjOther.Color;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 階層レベル
                /// </summary>
                public int Level;

                /// <summary>
                /// 親ID
                /// </summary>
                public int ParentID;

                /// <summary>
                /// 製品情報
                /// </summary>
                public List<WorkGroupSeihinInfo> SeihinInfo = new List<WorkGroupSeihinInfo>();

                /// <summary>
                /// 製作工程ID
                /// </summary>
                public int WorkProcessID;

                /// <summary>
                /// 完成予定日
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddHHmmss
                /// </remarks>
                public string CompleteDate = "";

                /// <summary>
                /// 実行順
                /// </summary>
                public int WorkOrder;

                /// <summary>
                /// 名称
                /// </summary>
                public List<WorkGroupNameInfo> NameInfo = new List<WorkGroupNameInfo>();

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color = new zPMxCom.typ.Color(0, 255, 255, 255);

                //-Prop----------------------------------------------------------------
                //
                // 機能　　　: 参照
                //
                // 取得値　　: 製作グループ名称
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 製作グループ名称
                /// </summary>
                public string Name
                {
                    get
                    {
                        string strResult = "";

                        for (int i = 0; i < this.NameInfo.Count; i++)
                        {
                            if (string.IsNullOrEmpty(this.NameInfo[i].Name) == false)
                            {
                                strResult += this.NameInfo[i].Name;
                                strResult += " ";
                            }
                        }

                        return strResult.TrimEnd(' ');
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: Equals()のオーバーライド
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// Equals()のオーバーライド
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public override bool Equals(object vobjOther)
                {
                    if (object.ReferenceEquals(vobjOther, null))
                    {
                        return false;
                    }

                    if (object.ReferenceEquals(this, vobjOther))
                    {
                        return true;
                    }

                    if (this.GetType() != vobjOther.GetType())
                    {
                        return false;
                    }

                    return this.Equals((WorkGroup)vobjOther);
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性の検証
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性の検証
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(WorkGroup vobjOther)
                {
                    do
                    {
                        if (this.FabID != vobjOther.FabID)
                        {
                            break;
                        }

                        if (this.Flag != vobjOther.Flag)
                        {
                            break;
                        }

                        if (this.ID != vobjOther.ID)
                        {
                            break;
                        }

                        if (this.Level != vobjOther.Level)
                        {
                            break;
                        }

                        if (this.ParentID != vobjOther.ParentID)
                        {
                            break;
                        }

                        if (this.WorkProcessID != vobjOther.WorkProcessID)
                        {
                            break;
                        }

                        if (this.CompleteDate != vobjOther.CompleteDate)
                        {
                            break;
                        }

                        if (this.WorkOrder != vobjOther.WorkOrder)
                        {
                            break;
                        }

                        if (this.Remarks != vobjOther.Remarks)
                        {
                            break;
                        }

                        if (this.Color.Equals(vobjOther.Color) == false)
                        {
                            break;
                        }

                        if (this.SeihinInfo.Count != vobjOther.SeihinInfo.Count)
                        {
                            break;
                        }

                        if (this.NameInfo.Count != vobjOther.NameInfo.Count)
                        {
                            break;
                        }

                        bool blnBreak = false;

                        for (int i = 0; i < this.SeihinInfo.Count; i++)
                        {
                            if (this.SeihinInfo[i].Equals(vobjOther.SeihinInfo[i]) == false)
                            {
                                blnBreak = true;

                                break;
                            }
                        }

                        if (blnBreak == true)
                        {
                            break;
                        }

                        for (int i = 0; i < this.NameInfo.Count; i++)
                        {
                            if (this.NameInfo[i].Equals(vobjOther.NameInfo[i]) == false)
                            {
                                blnBreak = true;

                                break;
                            }
                        }

                        if (blnBreak == true)
                        {
                            break;
                        }

                        return true;
                    }
                    while (false);

                    return false;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: ハッシュ値を取得する
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// ハッシュ値を取得する
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    int intResult = 1;

                    intResult ^= this.FabID;
                    intResult ^= this.Flag.GetHashCode();
                    intResult ^= this.ID;
                    intResult ^= this.Level;
                    intResult ^= this.ParentID;

                    foreach (WorkGroupSeihinInfo objWorkGroupSeihinInfo in this.SeihinInfo)
                    {
                        intResult ^= objWorkGroupSeihinInfo.GetHashCode();
                    }

                    intResult ^= this.WorkProcessID;
                    intResult ^= this.CompleteDate.GetHashCode();
                    intResult ^= this.WorkOrder;

                    foreach (WorkGroupNameInfo objWorkGroupNameInfo in this.NameInfo)
                    {
                        intResult ^= objWorkGroupNameInfo.GetHashCode();
                    }

                    intResult ^= this.Remarks.GetHashCode();
                    intResult ^= this.Color.GetHashCode();

                    return intResult;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 製作グループのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolWorkGroup     - in 製作グループ
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 製作グループのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolWorkGroup">製作グループ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.WorkGroup> vcolWorkGroup)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("WorkGroupData");
                            {
                                foreach (zPMxData.typ.WorkGroup objWorkGroup in vcolWorkGroup)
                                {
                                    objWriter.WriteStartElement("WorkGroup");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objWorkGroup.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objWorkGroup.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objWorkGroup.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Level");
                                        {
                                            objWriter.WriteString(objWorkGroup.Level.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ParentID");
                                        {
                                            objWriter.WriteString(objWorkGroup.ParentID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("SeihinInfo");
                                        {
                                            foreach (zPMxData.typ.WorkGroupSeihinInfo objWorkGroupSeihinInfo in objWorkGroup.SeihinInfo)
                                            {
                                                msubWrite_WorkGroupSeihinInfo(objWriter, objWorkGroupSeihinInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WorkProcessID");
                                        {
                                            objWriter.WriteString(objWorkGroup.WorkProcessID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompleteDate");
                                        {
                                            objWriter.WriteString(objWorkGroup.CompleteDate);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WorkOrder");
                                        {
                                            objWriter.WriteString(objWorkGroup.WorkOrder.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("NameInfo");
                                        {
                                            foreach (zPMxData.typ.WorkGroupNameInfo objWorkGroupNameInfo in objWorkGroup.NameInfo)
                                            {
                                                msubWrite_WorkGroupNameInfo(objWriter, objWorkGroupNameInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objWorkGroup.Remarks.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        zPMxCom.Write_Color(objWriter, "Color", objWorkGroup.Color);
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 製作グループのXML読み込み
                //
                // 引き数　　: vstrFilePath  - in ファイルパス
                // 　　　　　: rcolWorkGroup - out 製作グループ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 製作グループのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolWorkGroup">製作グループ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.WorkGroup> rcolWorkGroup)
                {
                    rcolWorkGroup = new List<WorkGroup>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.WorkGroup objWorkGroup = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "WorkGroup":
                                        {
                                            objWorkGroup = new WorkGroup();
                                            rcolWorkGroup.Add(objWorkGroup);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objWorkGroup.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objWorkGroup.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objWorkGroup.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Level":
                                        {
                                            objWorkGroup.Level = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ParentID":
                                        {
                                            objWorkGroup.ParentID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "SeihinInfo":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_WorkGroupSeihinInfoData(objReader.ReadSubtree(), ref objWorkGroup.SeihinInfo);
                                            }
                                        }
                                        break;

                                    case "WorkProcessID":
                                        {
                                            objWorkGroup.WorkProcessID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "CompleteDate":
                                        {
                                            objWorkGroup.CompleteDate = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "WorkOrder":
                                        {
                                            objWorkGroup.WorkOrder = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "NameInfo":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_WorkGroupNameInfo(objReader.ReadSubtree(), ref objWorkGroup.NameInfo);
                                            }
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objWorkGroup.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Color":
                                        {
                                            zPMxCom.Read_Color(objReader.ReadSubtree(), out objWorkGroup.Color);
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //---------------------------------------------------------------------
            //
            // 機能　　　: 製作グループ製品情報のXML書き出し
            //
            // 引き数　　: vobjWriter                - in XmlWriter
            // 　　　　　: vobjWorkGroupSeihinInfo   - in 製作グループ製品情報
            //
            // 備考　　　: 2020/ 6/16 - 金子　淳哉
            //
            //---------------------------------------------------------------------
            /// <summary>
            /// 製作グループ製品情報のXML書き出し
            /// </summary>
            /// <param name="vobjWriter">XmlWriter</param>
            /// <param name="vobjWorkGroupSeihinInfo">製作グループ製品情報</param>
            private static void msubWrite_WorkGroupSeihinInfo(XmlWriter vobjWriter, zPMxData.typ.WorkGroupSeihinInfo vobjWorkGroupSeihinInfo)
            {
                vobjWriter.WriteStartElement("WorkGroupSeihinInfo");
                {
                    vobjWriter.WriteStartElement("FabID");
                    {
                        vobjWriter.WriteString(vobjWorkGroupSeihinInfo.FabID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("Flag");
                    {
                        vobjWriter.WriteString(vobjWorkGroupSeihinInfo.Flag.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("WorkGroupID");
                    {
                        vobjWriter.WriteString(vobjWorkGroupSeihinInfo.WorkGroupID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("KoujiID");
                    {
                        vobjWriter.WriteString(vobjWorkGroupSeihinInfo.KoujiID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("SeihinID");
                    {
                        vobjWriter.WriteString(vobjWorkGroupSeihinInfo.SeihinID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("WorkOrder");
                    {
                        vobjWriter.WriteString(vobjWorkGroupSeihinInfo.WorkOrder.ToString());
                    }
                    vobjWriter.WriteEndElement();
                }
                vobjWriter.WriteEndElement();
            }

            //---------------------------------------------------------------------
            //
            // 機能　　　: 製作グループ名称のXML書き込み
            //
            // 引き数　　: vobjWriter            - in XmlWriter
            // 　　　　　: vobjWorkGroupNameInfo - in 製作グループ名称
            //
            // 備考　　　: 2020/ 6/16 - 金子　淳哉
            //
            //---------------------------------------------------------------------
            /// <summary>
            /// 製作グループ名称のXML書き込み
            /// </summary>
            /// <param name="vobjWriter">XmlWriter</param>
            /// <param name="vobjWorkGroupNameInfo">製作グループ名称</param>
            private static void msubWrite_WorkGroupNameInfo(XmlWriter vobjWriter, zPMxData.typ.WorkGroupNameInfo vobjWorkGroupNameInfo)
            {
                vobjWriter.WriteStartElement("WorkGroupNameInfo");
                {
                    vobjWriter.WriteStartElement("FabID");
                    {
                        vobjWriter.WriteString(vobjWorkGroupNameInfo.FabID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("Flag");
                    {
                        vobjWriter.WriteString(vobjWorkGroupNameInfo.Flag.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("WorkGroupID");
                    {
                        vobjWriter.WriteString(vobjWorkGroupNameInfo.WorkGroupID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("Name");
                    {
                        vobjWriter.WriteString(vobjWorkGroupNameInfo.Name);
                    }
                    vobjWriter.WriteEndElement();
                }
                vobjWriter.WriteEndElement();
            }

            //-------------------------------------------------------------------------
            // Title   : 製作グループ製品情報
            // Date    : 2020/ 5/19
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 製作グループ製品情報
            /// </summary>
            public class WorkGroupSeihinInfo : IEquatable<WorkGroupSeihinInfo>
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public WorkGroupSeihinInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WorkGroupSeihinInfo(WorkGroupSeihinInfo vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.WorkGroupID = vobjOther.WorkGroupID;
                    this.KoujiID = vobjOther.KoujiID;
                    this.SeihinID = vobjOther.SeihinID;
                    this.WorkOrder = vobjOther.WorkOrder;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 製作グループID
                /// </summary>
                public int WorkGroupID;

                /// <summary>
                /// 工事ID
                /// </summary>
                public int KoujiID;

                /// <summary>
                /// 製品ID
                /// </summary>
                public int SeihinID;

                /// <summary>
                /// 実行順
                /// </summary>
                public int WorkOrder;

                //---------------------------------------------------------------------
                //
                // 機能　　　: Equals()のオーバーライド
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// Equals()のオーバーライド
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public override bool Equals(object vobjOther)
                {
                    if (object.ReferenceEquals(vobjOther, null))
                    {
                        return false;
                    }

                    if (object.ReferenceEquals(this, vobjOther))
                    {
                        return true;
                    }

                    if (this.GetType() != vobjOther.GetType())
                    {
                        return false;
                    }

                    return this.Equals((WorkGroupSeihinInfo)vobjOther);
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性の検証
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性の検証
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(WorkGroupSeihinInfo vobjOther)
                {
                    do
                    {
                        if (this.FabID != vobjOther.FabID)
                        {
                            break;
                        }

                        if (this.Flag != vobjOther.Flag)
                        {
                            break;
                        }

                        if (this.WorkGroupID != vobjOther.WorkGroupID)
                        {
                            break;
                        }

                        if (this.KoujiID != vobjOther.KoujiID)
                        {
                            break;
                        }

                        if (this.SeihinID != vobjOther.SeihinID)
                        {
                            break;
                        }

                        if (this.WorkOrder != vobjOther.WorkOrder)
                        {
                            break;
                        }

                        return true;
                    }
                    while (false);

                    return false;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: ハッシュ値を取得する
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// ハッシュ値を取得する
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    return this.FabID ^
                           this.Flag.GetHashCode() ^
                           this.WorkGroupID ^
                           this.KoujiID ^
                           this.SeihinID ^
                           this.WorkOrder;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 製作グループ名称
            // Date    : 2020/ 6/ 2
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 製作グループ名称
            /// </summary>
            public class WorkGroupNameInfo : IEquatable<WorkGroupNameInfo>
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public WorkGroupNameInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WorkGroupNameInfo(WorkGroupNameInfo vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.WorkGroupID = vobjOther.WorkGroupID;
                    this.Name = vobjOther.Name;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 製作グループID
                /// </summary>
                public int WorkGroupID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: Equals()のオーバーライド
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// Equals()のオーバーライド
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public override bool Equals(object vobjOther)
                {
                    if (object.ReferenceEquals(vobjOther, null))
                    {
                        return false;
                    }

                    if (object.ReferenceEquals(this, vobjOther))
                    {
                        return true;
                    }

                    if (this.GetType() != vobjOther.GetType())
                    {
                        return false;
                    }

                    return this.Equals((WorkGroupNameInfo)vobjOther);
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性の検証
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性の検証
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(WorkGroupNameInfo vobjOther)
                {
                    do
                    {
                        if (this.FabID != vobjOther.FabID)
                        {
                            break;
                        }

                        if (this.Flag != vobjOther.Flag)
                        {
                            break;
                        }

                        if (this.WorkGroupID != vobjOther.WorkGroupID)
                        {
                            break;
                        }

                        if (this.Name != vobjOther.Name)
                        {
                            break;
                        }

                        return true;
                    }
                    while (false);

                    return false;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: ハッシュ値を取得する
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 6/ 2 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// ハッシュ値を取得する
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    return this.FabID ^
                           this.Flag.GetHashCode() ^
                           this.WorkGroupID ^
                           this.Name.GetHashCode();
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 材料グループ
            // Date    : 2020/ 5/ 8
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 材料グループ
            /// </summary>
            public class ZairyoGroup : zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ZairyoGroup()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/ 8 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ZairyoGroup(ZairyoGroup vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.ID = vobjOther.ID;
                    this.Name = vobjOther.Name;
                    
                    foreach (ZairyoGroupBuzaiInfo objZairyoGroupBuzaiInfo in vobjOther.BuzaiInfo)
                    {
                        this.BuzaiInfo.Add(new ZairyoGroupBuzaiInfo(objZairyoGroupBuzaiInfo));
                    }

                    this.OrderDate = vobjOther.OrderDate;
                    this.DeliveryDate = vobjOther.DeliveryDate;
                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 部材情報
                /// </summary>
                public List<ZairyoGroupBuzaiInfo> BuzaiInfo = new List<ZairyoGroupBuzaiInfo>();

                /// <summary>
                /// 発注日
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddHHmmss
                /// </remarks>
                public string OrderDate = "";

                /// <summary>
                /// 納入日
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddHHmmss
                /// </remarks>
                public string DeliveryDate = "";

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: 材料グループのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolZairyoGroup   - in 材料グループ
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 材料グループのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolZairyoGroup">材料グループ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.ZairyoGroup> vcolZairyoGroup)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("ZairyoGroupData");
                            {
                                foreach (zPMxData.typ.ZairyoGroup objZairyoGroup in vcolZairyoGroup)
                                {
                                    objWriter.WriteStartElement("ZairyoGroup");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objZairyoGroup.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objZairyoGroup.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objZairyoGroup.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objZairyoGroup.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("BuzaiInfo");
                                        {
                                            foreach (zPMxData.typ.ZairyoGroupBuzaiInfo objZairyoGroupBuzaiInfo in objZairyoGroup.BuzaiInfo)
                                            {
                                                msubWrite_ZairyoGroupBuzaiInfo(objWriter, objZairyoGroupBuzaiInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("OrderDate");
                                        {
                                            objWriter.WriteString(objZairyoGroup.OrderDate.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DeliveryDate");
                                        {
                                            objWriter.WriteString(objZairyoGroup.DeliveryDate);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objZairyoGroup.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 材料グループのXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolZairyoGroup   - i/o 材料グループ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 材料グループのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolZairyoGroup">材料グループ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.ZairyoGroup> rcolZairyoGroup)
                {
                    rcolZairyoGroup = new List<ZairyoGroup>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.ZairyoGroup objZairyoGroup = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "ZairyoGroup":
                                        {
                                            objZairyoGroup = new ZairyoGroup();
                                            rcolZairyoGroup.Add(objZairyoGroup);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objZairyoGroup.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objZairyoGroup.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objZairyoGroup.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objZairyoGroup.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "BuzaiInfo":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_ZairyoGroupBuzaiInfoData(objReader.ReadSubtree(), ref objZairyoGroup.BuzaiInfo);
                                            }
                                        }
                                        break;

                                    case "OrderDate":
                                        {
                                            objZairyoGroup.OrderDate = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "DeliveryDate":
                                        {
                                            objZairyoGroup.DeliveryDate = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objZairyoGroup.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 材料グループ部材情報
            // Date    : 2020/ 5/19
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 材料グループ部材情報
            /// </summary>
            public class ZairyoGroupBuzaiInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ZairyoGroupBuzaiInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ZairyoGroupBuzaiInfo(ZairyoGroupBuzaiInfo vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.ZairyoGroupID = vobjOther.ZairyoGroupID;
                    this.KoujiID = vobjOther.KoujiID;
                    this.BuzaiID = vobjOther.BuzaiID;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 材料グループID
                /// </summary>
                public int ZairyoGroupID;

                /// <summary>
                /// 工事ID
                /// </summary>
                public int KoujiID;

                /// <summary>
                /// 部材ID
                /// </summary>
                public int BuzaiID;
            }

            //-------------------------------------------------------------------------
            // Title   : 出荷グループ
            // Date    : 2020/ 5/ 8
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 出荷グループ
            /// </summary>
            public class ShippingGroup : zPMxCom.IPMData
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ShippingGroup()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ShippingGroup(ShippingGroup vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.ID = vobjOther.ID;
                    this.Name = vobjOther.Name;
                    
                    foreach (ShippingGroupSeihinInfo objShippingGroupSeihinInfo in vobjOther.SeihinInfo)
                    {
                        this.SeihinInfo.Add(new ShippingGroupSeihinInfo(objShippingGroupSeihinInfo));
                    }

                    this.Date = vobjOther.Date;
                    this.Remarks = vobjOther.Remarks;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 製品情報
                /// </summary>
                public List<ShippingGroupSeihinInfo> SeihinInfo = new List<ShippingGroupSeihinInfo>();

                /// <summary>
                /// 出荷日
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddHHmmss
                /// </remarks>
                public string Date = "";

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: 出荷グループのXML書き出し
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolShippingGroup - in 出荷グループ
                //
                // 備考　　　: 2020/ 6/16 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 出荷グループのXML書き出し
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolShippingGroup">出荷グループ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxData.typ.ShippingGroup> vcolShippingGroup)
                {
                    // XMLファイル書き込み設定
                    var objSettings = new XmlWriterSettings();
                    {
                        objSettings.Indent = false;
                    }

                    using (var objWriter = XmlWriter.Create(vstrFilePath, objSettings))
                    {
                        objWriter.WriteStartElement("root");
                        {
                            objWriter.WriteStartElement("ShippingGroupData");
                            {
                                foreach (zPMxData.typ.ShippingGroup objShippingGroup in vcolShippingGroup)
                                {
                                    objWriter.WriteStartElement("ShippingGroup");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objShippingGroup.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objShippingGroup.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objShippingGroup.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objShippingGroup.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("SeihinInfo");
                                        {
                                            foreach (zPMxData.typ.ShippingGroupSeihinInfo objShippingGroupSeihinInfo in objShippingGroup.SeihinInfo)
                                            {
                                                msubWrite_ShippingGroupSeihinInfo(objWriter, objShippingGroupSeihinInfo);
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Date");
                                        {
                                            objWriter.WriteString(objShippingGroup.Date);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Remarks");
                                        {
                                            objWriter.WriteString(objShippingGroup.Remarks);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 出荷グループのXML読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolShippingGroup - out 出荷グループ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 6/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 出荷グループのXML読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolShippingGroup">出荷グループ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxData.typ.ShippingGroup> rcolShippingGroup)
                {
                    rcolShippingGroup = new List<ShippingGroup>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxData.typ.ShippingGroup objShippingGroup = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "ShippingGroup":
                                        {
                                            objShippingGroup = new ShippingGroup();
                                            rcolShippingGroup.Add(objShippingGroup);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objShippingGroup.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objShippingGroup.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objShippingGroup.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objShippingGroup.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "SeihinInfo":
                                        {
                                            if (objReader.IsEmptyElement == true)
                                            {
                                                objReader.Read();
                                            }
                                            else
                                            {
                                                msubRead_ShippingGroupSeihinInfoData(objReader.ReadSubtree(), ref objShippingGroup.SeihinInfo);
                                            }
                                        }
                                        break;

                                    case "Date":
                                        {
                                            objShippingGroup.Date = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Remarks":
                                        {
                                            objShippingGroup.Remarks = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    default:
                                        {
                                            objReader.Read();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                objReader.Read();
                            }
                        }
                    }

                    return true;
                }
            }

            //---------------------------------------------------------------------
            //
            // 機能　　　: 出荷グループ製品情報のXML書き込み
            //
            // 引き数　　: vobjWriter                    - in XmlWriter
            // 　　　　　: vobjShippingGroupSeihinInfo   - in 出荷グループ製品情報
            //
            // 備考　　　: 2020/ 6/16 - 金子　淳哉
            //
            //---------------------------------------------------------------------
            /// <summary>
            /// 出荷グループ製品情報のXML書き込み
            /// </summary>
            /// <param name="vobjWriter">XmlWriter</param>
            /// <param name="vobjShippingGroupSeihinInfo">出荷グループ製品情報</param>
            private static void msubWrite_ShippingGroupSeihinInfo(XmlWriter vobjWriter, zPMxData.typ.ShippingGroupSeihinInfo vobjShippingGroupSeihinInfo)
            {
                vobjWriter.WriteStartElement("ShippingGroupSeihinInfo");
                {
                    vobjWriter.WriteStartElement("FabID");
                    {
                        vobjWriter.WriteString(vobjShippingGroupSeihinInfo.FabID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("Flag");
                    {
                        vobjWriter.WriteString(vobjShippingGroupSeihinInfo.Flag.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("ShippingGroupID");
                    {
                        vobjWriter.WriteString(vobjShippingGroupSeihinInfo.ShippingGroupID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("KoujiID");
                    {
                        vobjWriter.WriteString(vobjShippingGroupSeihinInfo.KoujiID.ToString());
                    }
                    vobjWriter.WriteEndElement();

                    vobjWriter.WriteStartElement("SeihinID");
                    {
                        vobjWriter.WriteString(vobjShippingGroupSeihinInfo.SeihinID.ToString());
                    }
                    vobjWriter.WriteEndElement();
                }
                vobjWriter.WriteEndElement();
            }

            //-------------------------------------------------------------------------
            // Title   : 出荷グループ製品情報
            // Date    : 2020/ 5/19
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 出荷グループ製品情報
            /// </summary>
            public class ShippingGroupSeihinInfo
            {
                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public ShippingGroupSeihinInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ShippingGroupSeihinInfo(ShippingGroupSeihinInfo vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.ShippingGroupID = vobjOther.ShippingGroupID;
                    this.KoujiID = vobjOther.KoujiID;
                    this.SeihinID = vobjOther.SeihinID;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 出荷グループID
                /// </summary>
                public int ShippingGroupID;

                /// <summary>
                /// 工事ID
                /// </summary>
                public int KoujiID;

                /// <summary>
                /// 製品ID
                /// </summary>
                public int SeihinID;
            }
        }//End Class

        //---------------------------------------------------------------------
        //
        // 機能　　　: ３Ｄ座標のXML書き出し
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vstrName      - in 項目名
        // 　　　　　: vusrPoint3D   - in ３Ｄ座標
        //
        // 備考　　　: 2020/ 6/15 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ３Ｄ座標のXML書き出し
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vstrName">項目名</param>
        /// <param name="vusrPoint3D">３Ｄ座標</param>
        private static void msubWrite_Point3D(XmlWriter vobjWriter, string vstrName, zPMxCom.typ.Point3D vusrPoint3D)
        {
            vobjWriter.WriteStartElement(vstrName);
            {
                vobjWriter.WriteStartElement("X");
                {
                    vobjWriter.WriteString(vusrPoint3D.X.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Y");
                {
                    vobjWriter.WriteString(vusrPoint3D.Y.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Z");
                {
                    vobjWriter.WriteString(vusrPoint3D.Z.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 座標のXML書き出し
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vstrName      - in 項目名
        // 　　　　　: vusrPoint     - in 座標
        //
        // 備考　　　: 2020/ 6/15 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 座標のXML書き出し
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vstrName">項目名</param>
        /// <param name="vusrPoint">座標</param>
        private static void msubWrite_Point(XmlWriter vobjWriter, string vstrName, zPMxCom.typ.Point vusrPoint)
        {
            vobjWriter.WriteStartElement(vstrName);
            {
                vobjWriter.WriteStartElement("X");
                {
                    vobjWriter.WriteString(vusrPoint.X.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Y");
                {
                    vobjWriter.WriteString(vusrPoint.Y.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 端部情報のXML書き出し
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vstrName      - in 項目名
        // 　　　　　: vobjEdgeInfo  - in 端部情報
        //
        // 備考　　　: 2020/ 6/15 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 端部情報のXML書き出し
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vstrName">項目名</param>
        /// <param name="vobjEdgeInfo">端部情報</param>
        private static void msubWrite_EdgeInfo(XmlWriter vobjWriter, string vstrName, zPMxData.typ.EdgeInfo vobjEdgeInfo)
        {
            vobjWriter.WriteStartElement(vstrName);
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BuzaiID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.BuzaiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.ID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Type");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.Type.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ConnectKind");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.ConnectKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ConnectID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.ConnectID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ConnectDataID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.ConnectDataID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ConnectPartsNo");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.ConnectPartsNo.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("JointName");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.JointName.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Edge_DataID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.Edge_DataID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Edge_BuhinID");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.Edge_BuhinID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ScallopInfoData");
                {
                    foreach (zPMxData.typ.EdgeScallopInfo objEdgeScallopInfo in vobjEdgeInfo.ScallopInfo)
                    {
                        vobjWriter.WriteStartElement("ScallopInfo");
                        {
                            vobjWriter.WriteStartElement("FabID");
                            {
                                vobjWriter.WriteString(objEdgeScallopInfo.FabID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("KoujiID");
                            {
                                vobjWriter.WriteString(objEdgeScallopInfo.KoujiID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("Flag");
                            {
                                vobjWriter.WriteString(objEdgeScallopInfo.Flag.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("BuzaiID");
                            {
                                vobjWriter.WriteString(objEdgeScallopInfo.BuzaiID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("SubID");
                            {
                                vobjWriter.WriteString(objEdgeScallopInfo.SubID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("Kind");
                            {
                                vobjWriter.WriteString(objEdgeScallopInfo.Kind.ToString());
                            }
                            vobjWriter.WriteEndElement();
                        }
                        vobjWriter.WriteEndElement();
                    }
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("WeldGroInfoData");
                {
                    foreach (zPMxData.typ.EdgeWeldGroInfo objEdgeWeldGroInfo in vobjEdgeInfo.WeldGroInfo)
                    {
                        vobjWriter.WriteStartElement("WeldGroInfo");
                        {
                            vobjWriter.WriteStartElement("FabID");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.FabID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("KoujiID");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.KoujiID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("Flag");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.Flag.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("BuzaiID");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.BuzaiID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("SubID");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.SubID.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("TipKind");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.TipKind.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("WeldAngle1");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.WeldAngle1.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("WeldAngle2");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.WeldAngle2.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("WeldDepth1");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.WeldDepth1.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("WeldDepth2");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.WeldDepth2.ToString());
                            }
                            vobjWriter.WriteEndElement();

                            vobjWriter.WriteStartElement("RG");
                            {
                                vobjWriter.WriteString(objEdgeWeldGroInfo.RG.ToString());
                            }
                            vobjWriter.WriteEndElement();
                        }
                        vobjWriter.WriteEndElement();
                    }
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("WeldLen");
                {
                    vobjWriter.WriteString(vobjEdgeInfo.WeldLen.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 穴情報のXML書き出し
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vobjHoleInfo  - in 穴情報
        //
        // 備考　　　: 2020/ 6/15 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 穴情報のXML書き出し
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjHoleInfo">穴情報</param>
        private static void msubWrite_HoleInfo(XmlWriter vobjWriter, zPMxData.typ.HoleInfo vobjHoleInfo)
        {
            vobjWriter.WriteStartElement("HoleInfo");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjHoleInfo.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjHoleInfo.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjHoleInfo.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BuzaiID");
                {
                    vobjWriter.WriteString(vobjHoleInfo.BuzaiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Kind");
                {
                    vobjWriter.WriteString(vobjHoleInfo.Kind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Shape");
                {
                    vobjWriter.WriteString(vobjHoleInfo.Shape.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("FaceNo");
                {
                    vobjWriter.WriteString(vobjHoleInfo.FaceNo.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "Pos", vobjHoleInfo.Pos);

                msubWrite_Point3D(vobjWriter, "Vector", vobjHoleInfo.Vector);

                vobjWriter.WriteStartElement("Dia");
                {
                    vobjWriter.WriteString(vobjHoleInfo.Dia.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Width");
                {
                    vobjWriter.WriteString(vobjHoleInfo.Width.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "TiltVector", vobjHoleInfo.TiltVector);

                vobjWriter.WriteStartElement("SleeveKind");
                {
                    vobjWriter.WriteString(vobjHoleInfo.SleeveKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BoltID");
                {
                    vobjWriter.WriteString(vobjHoleInfo.BoltID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BoltDia");
                {
                    vobjWriter.WriteString(vobjHoleInfo.BoltDia.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BoltLength");
                {
                    vobjWriter.WriteString(vobjHoleInfo.BoltLength.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("AnchorBoltKind");
                {
                    vobjWriter.WriteString(vobjHoleInfo.AnchorBoltKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("AnchorBoltStd");
                {
                    vobjWriter.WriteString(vobjHoleInfo.AnchorBoltStd.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 切り欠き情報のXML書き込み
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vobjNotchInfo - in 切り欠き情報
        //
        // 備考　　　: 2020/ 6/16 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 切り欠き情報のXML書き込み
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjNotchInfo">切り欠き情報</param>
        private static void msubWrite_NotchInfo(XmlWriter vobjWriter, zPMxData.typ.NotchInfo vobjNotchInfo)
        {
            vobjWriter.WriteStartElement("NotchInfo");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjNotchInfo.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjNotchInfo.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjNotchInfo.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BuzaiID");
                {
                    vobjWriter.WriteString(vobjNotchInfo.BuzaiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ID");
                {
                    vobjWriter.WriteString(vobjNotchInfo.ID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Kind");
                {
                    vobjWriter.WriteString(vobjNotchInfo.Kind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("FigData");
                {
                    foreach (zPMxData.typ.NotchFig objNotchFig in vobjNotchInfo.Fig)
                    {
                        msubWrite_NotchFig(vobjWriter, objNotchFig);
                    }
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 切り欠き図形のXML書き込み
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vobjNotchFig  - in 切り欠き図形
        //
        // 備考　　　: 2020/ 6/16 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 切り欠き図形のXML書き込み
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjNotchFig">切り欠き図形</param>
        private static void msubWrite_NotchFig(XmlWriter vobjWriter, zPMxData.typ.NotchFig vobjNotchFig)
        {
            vobjWriter.WriteStartElement("NotchFig");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjNotchFig.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjNotchFig.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjNotchFig.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BuzaiID");
                {
                    vobjWriter.WriteString(vobjNotchFig.BuzaiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("NotchID");
                {
                    vobjWriter.WriteString(vobjNotchFig.NotchID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Figure2DKind");
                {
                    vobjWriter.WriteString(vobjNotchFig.Figure2DKind.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "Ps", vobjNotchFig.Ps);

                msubWrite_Point3D(vobjWriter, "Pe", vobjNotchFig.Pe);

                msubWrite_Point3D(vobjWriter, "Pc", vobjNotchFig.Pc);

                msubWrite_Point3D(vobjWriter, "LPos", vobjNotchFig.LPos);

                msubWrite_Point3D(vobjWriter, "SPos", vobjNotchFig.SPos);

                vobjWriter.WriteStartElement("Direction");
                {
                    vobjWriter.WriteString(vobjNotchFig.Direction.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("R");
                {
                    vobjWriter.WriteString(vobjNotchFig.R.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 構成材料情報のXML書き込み
        //
        // 引き数　　: vobjWriter            - in XmlWriter
        // 　　　　　: vobjComponentInfo     - in 構成材料情報
        //
        // 備考　　　: 2020/ 6/16 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 構成材料情報のXML書き込み
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjComponentInfo">構成材料情報</param>
        private static void msubWrite_ComponentInfo(XmlWriter vobjWriter, zPMxData.typ.ComponentInfo vobjComponentInfo)
        {
            vobjWriter.WriteStartElement("ComponentInfo");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjComponentInfo.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjComponentInfo.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjComponentInfo.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BaseKind");
                {
                    vobjWriter.WriteString(vobjComponentInfo.BaseKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BaseID");
                {
                    vobjWriter.WriteString(vobjComponentInfo.BaseID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ID");
                {
                    vobjWriter.WriteString(vobjComponentInfo.ID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Kind");
                {
                    vobjWriter.WriteString(vobjComponentInfo.Kind.ToString());
                }
                vobjWriter.WriteEndElement();

                switch (vobjComponentInfo.Kind)
                {
                    case enm.ComponentKind.Buzai:
                        {
                            var objConInfoBuzai = (zPMxData.typ.ConInfoBuzai)vobjComponentInfo.ConInfo;

                            vobjWriter.WriteStartElement("ConInfoBuzai");
                            {
                                vobjWriter.WriteStartElement("BuzaiID");
                                {
                                    vobjWriter.WriteString(objConInfoBuzai.BuzaiID.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                vobjWriter.WriteStartElement("Type");
                                {
                                    vobjWriter.WriteString(objConInfoBuzai.Type.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                vobjWriter.WriteStartElement("DataID");
                                {
                                    vobjWriter.WriteString(objConInfoBuzai.DataID.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                vobjWriter.WriteStartElement("PartsNo");
                                {
                                    vobjWriter.WriteString(objConInfoBuzai.PartsNo.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                vobjWriter.WriteStartElement("Code");
                                {
                                    vobjWriter.WriteString(objConInfoBuzai.Code.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                vobjWriter.WriteStartElement("WeldInfoData");
                                {
                                    foreach (zPMxData.typ.WeldInfo objWeldInfo in objConInfoBuzai.WeldInfo)
                                    {
                                        msubWrite_WeldInfo(vobjWriter, objWeldInfo);
                                    }
                                }
                                vobjWriter.WriteEndElement();
                            }
                            vobjWriter.WriteEndElement();
                        }
                        break;

                    case enm.ComponentKind.Kataita:
                        {
                            var objConInfoKataita = (zPMxData.typ.ConInfoKataita)vobjComponentInfo.ConInfo;

                            vobjWriter.WriteStartElement("ConInfoKataita");
                            {
                                vobjWriter.WriteStartElement("KataitaID");
                                {
                                    vobjWriter.WriteString(objConInfoKataita.KataitaID.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                vobjWriter.WriteStartElement("PartsData");
                                {
                                    foreach (zPMxData.typ.KataitaParts objKataitaParts in objConInfoKataita.Parts)
                                    {
                                        msubWrite_KataitaParts(vobjWriter, objKataitaParts);
                                    }
                                }
                                vobjWriter.WriteEndElement();
                            }
                            vobjWriter.WriteEndElement();
                        }
                        break;

                    case enm.ComponentKind.Buhin:
                        {
                            var objConInfoBuhin = (zPMxData.typ.ConInfoBuhin)vobjComponentInfo.ConInfo;

                            vobjWriter.WriteStartElement("ConInfoBuhin");
                            {
                                vobjWriter.WriteStartElement("BuhinID");
                                {
                                    vobjWriter.WriteString(objConInfoBuhin.BuhinID.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                vobjWriter.WriteStartElement("CoordKind");
                                {
                                    vobjWriter.WriteString(objConInfoBuhin.CoordKind.ToString());
                                }
                                vobjWriter.WriteEndElement();

                                if (objConInfoBuhin.Coord != null)
                                {
                                    switch (objConInfoBuhin.CoordKind)
                                    {
                                        case enm.CoordKind.Straight:
                                            {
                                                var objCoord = (zPMxData.typ.Coord)objConInfoBuhin.Coord;

                                                msubWrite_Coord(vobjWriter, objCoord);
                                            }
                                            break;

                                        case enm.CoordKind.Arch:
                                            {
                                                var objCoordArch = (zPMxData.typ.CoordArch)objConInfoBuhin.Coord;

                                                msubWrite_CoordArch(vobjWriter, objCoordArch);
                                            }
                                            break;
                                    }
                                }

                                vobjWriter.WriteStartElement("WeldInfoData");
                                {
                                    foreach (zPMxData.typ.WeldInfo objWeldInfo in objConInfoBuhin.WeldInfo)
                                    {
                                        msubWrite_WeldInfo(vobjWriter, objWeldInfo);
                                    }
                                }
                                vobjWriter.WriteEndElement();
                            }
                            vobjWriter.WriteEndElement();
                        }
                        break;
                }
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 溶接情報のXML書き出し
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vobjWeldInfo  - in 溶接情報
        //
        // 備考　　　: 2020/ 6/15 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 溶接情報のXML書き出し
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjWeldInfo">溶接情報</param>
        private static void msubWrite_WeldInfo(XmlWriter vobjWriter, zPMxData.typ.WeldInfo vobjWeldInfo)
        {
            vobjWriter.WriteStartElement("WeldInfo");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjWeldInfo.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BaseKind");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BaseKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BaseID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BaseID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("CompID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.CompID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BuiIndex");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BuiIndex.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ElementKind");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ElementKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BasePlateKind");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BasePlateKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Kind");
                {
                    vobjWriter.WriteString(vobjWeldInfo.Kind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Side");
                {
                    vobjWriter.WriteString(vobjWeldInfo.Side.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Place");
                {
                    vobjWriter.WriteString(vobjWeldInfo.Place.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("TipKind");
                {
                    vobjWriter.WriteString(vobjWeldInfo.TipKind.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("WeldAngle1");
                {
                    vobjWriter.WriteString(vobjWeldInfo.WeldAngle1.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("WeldAngle2");
                {
                    vobjWriter.WriteString(vobjWeldInfo.WeldAngle2.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("WeldDepth1");
                {
                    vobjWriter.WriteString(vobjWeldInfo.WeldDepth1.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("WeldDepth2");
                {
                    vobjWriter.WriteString(vobjWeldInfo.WeldDepth2.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("RG");
                {
                    vobjWriter.WriteString(vobjWeldInfo.RG.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("WeldLen");
                {
                    vobjWriter.WriteString(vobjWeldInfo.WeldLen.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("UT");
                {
                    vobjWriter.WriteString(vobjWeldInfo.UT.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BPL_KindID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BPL_KindID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BPL_StdID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BPL_StdID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BPL_Thick");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BPL_Thick.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BPL_Width");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BPL_Width.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BPL_Length");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BPL_Length.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BPL_Count");
                {
                    vobjWriter.WriteString(vobjWeldInfo.BPL_Count.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ET_KindID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ET_KindID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ET_StdID");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ET_StdID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ET_Thick");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ET_Thick.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ET_Width");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ET_Width.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ET_Width2");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ET_Width2.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ET_Length");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ET_Length.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ET_Count");
                {
                    vobjWriter.WriteString(vobjWeldInfo.ET_Count.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 板構成データ接続情報のXML書き込み
        //
        // 引き数　　: vobjWriter        - in XmlWriter
        // 　　　　　: vobjKataitaParts  - in 板構成データ接続情報
        //
        // 備考　　　: 2020/ 6/15 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 板構成データ接続情報のXML書き込み
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjKataitaParts">板構成データ接続情報</param>
        private static void msubWrite_KataitaParts(XmlWriter vobjWriter, zPMxData.typ.KataitaParts vobjKataitaParts)
        {
            vobjWriter.WriteStartElement("KataitaParts");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjKataitaParts.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjKataitaParts.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjKataitaParts.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("CompID");
                {
                    vobjWriter.WriteString(vobjKataitaParts.CompID.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "Pos3D_0", vobjKataitaParts.Pos3D[0]);
                msubWrite_Point3D(vobjWriter, "Pos3D_1", vobjKataitaParts.Pos3D[1]);
                msubWrite_Point3D(vobjWriter, "Pos3D_2", vobjKataitaParts.Pos3D[2]);

                vobjWriter.WriteStartElement("SideInfoData");
                {
                    foreach (zPMxData.typ.KataitaSideInfo objKataitaSideInfo in vobjKataitaParts.SideInfo)
                    {
                        msubWrite_KataitaSideInfo(vobjWriter, objKataitaSideInfo);
                    }
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 板辺接続情報のXML書き込み
        //
        // 引き数　　: vobjWriter            - in XmlWriter
        // 　　　　　: vobjKataitaSideInfo   - in 板辺接続情報
        //
        // 備考　　　: 2020/ 6/15 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 板辺接続情報のXML書き込み
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjKataitaSideInfo">板辺接続情報</param>
        private static void msubWrite_KataitaSideInfo(XmlWriter vobjWriter, zPMxData.typ.KataitaSideInfo vobjKataitaSideInfo)
        {
            vobjWriter.WriteStartElement("KataitaSideInfo");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KataitaID");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.KataitaID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ConInfoID");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.ConInfoID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("PartsID");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.PartsID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ID");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.ID.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "ConLine_Ps", vobjKataitaSideInfo.ConLine.Ps);

                msubWrite_Point3D(vobjWriter, "ConLine_Pe", vobjKataitaSideInfo.ConLine.Pe);

                msubWrite_Point3D(vobjWriter, "Vector", vobjKataitaSideInfo.Vector);

                vobjWriter.WriteStartElement("FaceNo");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.FaceNo.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("FaceEx");
                {
                    vobjWriter.WriteString(vobjKataitaSideInfo.FaceEx.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_WeldInfo(vobjWriter, vobjKataitaSideInfo.WeldInfo);
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: ３Ｄ構造のXML書き込み
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vobjCoord     - in ３Ｄ構造
        //
        // 備考　　　: 2020/ 6/16 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ３Ｄ構造のXML書き込み
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjCoord">３Ｄ構造</param>
        private static void msubWrite_Coord(XmlWriter vobjWriter, zPMxData.typ.Coord vobjCoord)
        {
            vobjWriter.WriteStartElement("Coord");
            {
                msubWrite_Point3D(vobjWriter, "Core_Ps", vobjCoord.Core.Ps);
                msubWrite_Point3D(vobjWriter, "Core_Pe", vobjCoord.Core.Pe);

                msubWrite_Point3D(vobjWriter, "Center_Ps", vobjCoord.Center.Ps);
                msubWrite_Point3D(vobjWriter, "Center_Pe", vobjCoord.Center.Pe);

                msubWrite_Point3D(vobjWriter, "FrameLU_Ps", vobjCoord.FrameLU.Ps);
                msubWrite_Point3D(vobjWriter, "FrameLU_Pe", vobjCoord.FrameLU.Pe);

                msubWrite_Point3D(vobjWriter, "FrameRU_Ps", vobjCoord.FrameRU.Ps);
                msubWrite_Point3D(vobjWriter, "FrameRU_Pe", vobjCoord.FrameRU.Pe);

                msubWrite_Point3D(vobjWriter, "FrameLD_Ps", vobjCoord.FrameLD.Ps);
                msubWrite_Point3D(vobjWriter, "FrameLD_Pe", vobjCoord.FrameLD.Pe);

                msubWrite_Point3D(vobjWriter, "FrameRD_Ps", vobjCoord.FrameRD.Ps);
                msubWrite_Point3D(vobjWriter, "FrameRD_Pe", vobjCoord.FrameRD.Pe);
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: ３Ｄ構造アーチ用のXML書き込み
        //
        // 引き数　　: vobjWriter    - in XmlWriter
        // 　　　　　: vobjCoordArch - in ３Ｄ構造アーチ用
        //
        // 備考　　　: 2020/ 6/16 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ３Ｄ構造アーチ用のXML書き込み
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjCoordArch">３Ｄ構造アーチ用</param>
        private static void msubWrite_CoordArch(XmlWriter vobjWriter, zPMxData.typ.CoordArch vobjCoordArch)
        {
            vobjWriter.WriteStartElement("CoordArch");
            {
                msubWrite_Point3D(vobjWriter, "Core_Pc", vobjCoordArch.Core.Pc);
                msubWrite_Point3D(vobjWriter, "Core_Ps", vobjCoordArch.Core.Ps);
                msubWrite_Point3D(vobjWriter, "Core_Pe", vobjCoordArch.Core.Pe);
                msubWrite_Point3D(vobjWriter, "Core_Vector", vobjCoordArch.Core.Vector);

                vobjWriter.WriteStartElement("Core_R");
                {
                    vobjWriter.WriteString(vobjCoordArch.Core.R.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Core_Direction");
                {
                    vobjWriter.WriteString(vobjCoordArch.Core.Direction.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "Center_Pc", vobjCoordArch.Center.Pc);
                msubWrite_Point3D(vobjWriter, "Center_Ps", vobjCoordArch.Center.Ps);
                msubWrite_Point3D(vobjWriter, "Center_Pe", vobjCoordArch.Center.Pe);
                msubWrite_Point3D(vobjWriter, "Center_Vector", vobjCoordArch.Center.Vector);

                vobjWriter.WriteStartElement("Center_R");
                {
                    vobjWriter.WriteString(vobjCoordArch.Center.R.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Center_Direction");
                {
                    vobjWriter.WriteString(vobjCoordArch.Center.Direction.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "FrameLU_Pc", vobjCoordArch.FrameLU.Pc);
                msubWrite_Point3D(vobjWriter, "FrameLU_Ps", vobjCoordArch.FrameLU.Ps);
                msubWrite_Point3D(vobjWriter, "FrameLU_Pe", vobjCoordArch.FrameLU.Pe);
                msubWrite_Point3D(vobjWriter, "FrameLU_Vector", vobjCoordArch.FrameLU.Vector);

                vobjWriter.WriteStartElement("FrameLU_R");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameLU.R.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("FrameLU_Direction");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameLU.Direction.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "FrameRU_Pc", vobjCoordArch.FrameRU.Pc);
                msubWrite_Point3D(vobjWriter, "FrameRU_Ps", vobjCoordArch.FrameRU.Ps);
                msubWrite_Point3D(vobjWriter, "FrameRU_Pe", vobjCoordArch.FrameRU.Pe);
                msubWrite_Point3D(vobjWriter, "FrameRU_Vector", vobjCoordArch.FrameRU.Vector);

                vobjWriter.WriteStartElement("FrameRU_R");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameRU.R.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("FrameRU_Direction");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameRU.Direction.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "FrameLD_Pc", vobjCoordArch.FrameLD.Pc);
                msubWrite_Point3D(vobjWriter, "FrameLD_Ps", vobjCoordArch.FrameLD.Ps);
                msubWrite_Point3D(vobjWriter, "FrameLD_Pe", vobjCoordArch.FrameLD.Pe);
                msubWrite_Point3D(vobjWriter, "FrameLD_Vector", vobjCoordArch.FrameLD.Vector);

                vobjWriter.WriteStartElement("FrameLD_R");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameLD.R.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("FrameLD_Direction");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameLD.Direction.ToString());
                }
                vobjWriter.WriteEndElement();

                msubWrite_Point3D(vobjWriter, "FrameRD_Pc", vobjCoordArch.FrameRD.Pc);
                msubWrite_Point3D(vobjWriter, "FrameRD_Ps", vobjCoordArch.FrameRD.Ps);
                msubWrite_Point3D(vobjWriter, "FrameRD_Pe", vobjCoordArch.FrameRD.Pe);
                msubWrite_Point3D(vobjWriter, "FrameRD_Vector", vobjCoordArch.FrameRD.Vector);

                vobjWriter.WriteStartElement("FrameRD_R");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameRD.R.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("FrameRD_Direction");
                {
                    vobjWriter.WriteString(vobjCoordArch.FrameRD.Direction.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 材料グループ部材情報のXML書き出し
        //
        // 引き数　　: vobjWriter                - in XmlWriter
        // 　　　　　: vobjZairyoGroupBuzaiInfo  - in 材料グループ部材情報
        //
        // 備考　　　: 2020/ 6/16 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 材料グループ部材情報のXML書き出し
        /// </summary>
        /// <param name="vobjWriter">XmlWriter</param>
        /// <param name="vobjZairyoGroupBuzaiInfo">材料グループ部材情報</param>
        private static void msubWrite_ZairyoGroupBuzaiInfo(XmlWriter vobjWriter, zPMxData.typ.ZairyoGroupBuzaiInfo vobjZairyoGroupBuzaiInfo)
        {
            vobjWriter.WriteStartElement("ZairyoGroupBuzaiInfo");
            {
                vobjWriter.WriteStartElement("FabID");
                {
                    vobjWriter.WriteString(vobjZairyoGroupBuzaiInfo.FabID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("Flag");
                {
                    vobjWriter.WriteString(vobjZairyoGroupBuzaiInfo.Flag.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("ZairyoGroupID");
                {
                    vobjWriter.WriteString(vobjZairyoGroupBuzaiInfo.ZairyoGroupID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("KoujiID");
                {
                    vobjWriter.WriteString(vobjZairyoGroupBuzaiInfo.KoujiID.ToString());
                }
                vobjWriter.WriteEndElement();

                vobjWriter.WriteStartElement("BuzaiID");
                {
                    vobjWriter.WriteString(vobjZairyoGroupBuzaiInfo.BuzaiID.ToString());
                }
                vobjWriter.WriteEndElement();
            }
            vobjWriter.WriteEndElement();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 端部情報のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: vstrName      - in 項目名
        // 　　　　　: robjEdgeInfo  - i/o 端部情報
        //
        // 備考　　　: 2020/ 6/17 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 端部情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vstrName">項目名</param>
        /// <param name="robjEdgeInfo">端部情報</param>
        private static void msubRead_EdgeInfo(XmlReader vobjReader, string vstrName, out zPMxData.typ.EdgeInfo robjEdgeInfo)
        {
            robjEdgeInfo = new typ.EdgeInfo();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "FabID":
                            {
                                robjEdgeInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                robjEdgeInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "BuzaiID":
                            {
                                robjEdgeInfo.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ID":
                            {
                                robjEdgeInfo.ID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Type":
                            {
                                robjEdgeInfo.Type = zPMxCom.Conv_StringToEnum<enm.EdgeType>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "ConnectKind":
                            {
                                robjEdgeInfo.ConnectKind = zPMxCom.Conv_StringToEnum<enm.EdgeConnectKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "ConnectID":
                            {
                                robjEdgeInfo.ConnectID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ConnectDataID":
                            {
                                robjEdgeInfo.ConnectDataID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ConnectPartsNo":
                            {
                                robjEdgeInfo.ConnectPartsNo = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "JointName":
                            {
                                robjEdgeInfo.JointName = vobjReader.ReadElementContentAsString();
                            }
                            break;

                        case "Edge_DataID":
                            {
                                robjEdgeInfo.Edge_DataID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Edge_BuhinID":
                            {
                                robjEdgeInfo.Edge_BuhinID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ScallopInfoData":
                            {
                                if (vobjReader.IsEmptyElement == true)
                                {
                                    vobjReader.Read();
                                }
                                else
                                {
                                    msubRead_ScallopInfoData(vobjReader.ReadSubtree(), ref robjEdgeInfo.ScallopInfo);
                                }
                            }
                            break;

                        case "WeldGroInfoData":
                            {
                                if (vobjReader.IsEmptyElement == true)
                                {
                                    vobjReader.Read();
                                }
                                else
                                {
                                    msubRead_WeldGroInfoData(vobjReader.ReadSubtree(), ref robjEdgeInfo.WeldGroInfo);
                                }
                            }
                            break;

                        case "WeldLen":
                            {
                                robjEdgeInfo.WeldLen = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: スカラップ情報のXML読み込み
        //
        // 引き数　　: vobjReader            - in XmlReader
        // 　　　　　: vcolEdgeScallopInfo   - i/o スカラップ情報
        //
        // 備考　　　: 2020/ 6/17 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// スカラップ情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolEdgeScallopInfo">スカラップ情報</param>
        private static void msubRead_ScallopInfoData(XmlReader vobjReader, ref List<zPMxData.typ.EdgeScallopInfo> vcolEdgeScallopInfo)
        {
            zPMxData.typ.EdgeScallopInfo objEdgeScallopInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "ScallopInfo":
                            {
                                objEdgeScallopInfo = new typ.EdgeScallopInfo();
                                vcolEdgeScallopInfo.Add(objEdgeScallopInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objEdgeScallopInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objEdgeScallopInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objEdgeScallopInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BuzaiID":
                            {
                                objEdgeScallopInfo.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "SubID":
                            {
                                objEdgeScallopInfo.SubID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Kind":
                            {
                                objEdgeScallopInfo.Kind = zPMxCom.Conv_StringToEnum<zPMxCom.enm.WeldScallopKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 穴情報のXML読み込み
        //
        // 引き数　　: vobjReader        - in XmlReader
        // 　　　　　: vcolHoleInfo      - i/o 穴情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 穴情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolHoleInfo">穴情報</param>
        private static void msubRead_HoleInfoData(XmlReader vobjReader, ref List<zPMxData.typ.HoleInfo> vcolHoleInfo)
        {
            zPMxData.typ.HoleInfo objHoleInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "HoleInfo":
                            {
                                objHoleInfo = new typ.HoleInfo();
                                vcolHoleInfo.Add(objHoleInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objHoleInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objHoleInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objHoleInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BuzaiID":
                            {
                                objHoleInfo.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Kind":
                            {
                                objHoleInfo.Kind = zPMxCom.Conv_StringToEnum<enm.HoleKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "Shape":
                            {
                                objHoleInfo.Shape = zPMxCom.Conv_StringToEnum<enm.HoleShape>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "FaceNo":
                            {
                                objHoleInfo.FaceNo = (byte)vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Pos":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objHoleInfo.Pos); ;
                            }
                            break;

                        case "Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objHoleInfo.Vector);
                            }
                            break;

                        case "Dia":
                            {
                                objHoleInfo.Dia = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Width":
                            {
                                objHoleInfo.Width = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "TiltVector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objHoleInfo.TiltVector);
                            }
                            break;

                        case "SleeveKind":
                            {
                                objHoleInfo.SleeveKind = zPMxCom.Conv_StringToEnum<enm.SleeveKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BoltID":
                            {
                                objHoleInfo.BoltID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "BoltDia":
                            {
                                objHoleInfo.BoltDia = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "BoltLength":
                            {
                                objHoleInfo.BoltLength = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "AnchorBoltKind":
                            {
                                objHoleInfo.AnchorBoltKind = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "AnchorBoltStd":
                            {
                                objHoleInfo.AnchorBoltStd = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 切り欠き情報のXML読み込み
        //
        // 引き数　　: vobjReader        - in XmlReader
        // 　　　　　: vcolNotchInfo     - i/o 切り欠き情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 切り欠き情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolNotchInfo">切り欠き情報</param>
        private static void msubRead_NotchInfoData(XmlReader vobjReader, ref List<zPMxData.typ.NotchInfo> vcolNotchInfo)
        {
            zPMxData.typ.NotchInfo objNotchInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "NotchInfo":
                            {
                                objNotchInfo = new typ.NotchInfo();
                                vcolNotchInfo.Add(objNotchInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objNotchInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objNotchInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objNotchInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BuzaiID":
                            {
                                objNotchInfo.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ID":
                            {
                                objNotchInfo.ID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Kind":
                            {
                                objNotchInfo.Kind = zPMxCom.Conv_StringToEnum<enm.NotchKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "FigData":
                            {
                                msubRead_NotchFigData(vobjReader.ReadSubtree(), ref objNotchInfo.Fig);
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 製作グループのXML読み込み
        //
        // 引き数　　: vobjReader                - in XmlReader
        // 　　　　　: vcolWorkGroupSeihinInfo   - i/o 製作グループ
        //
        // 備考　　　: 2020/ 6/19 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 製作グループのXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolWorkGroupSeihinInfo">製作グループ</param>
        private static void msubRead_WorkGroupSeihinInfoData(XmlReader vobjReader, ref List<zPMxData.typ.WorkGroupSeihinInfo> vcolWorkGroupSeihinInfo)
        {
            zPMxData.typ.WorkGroupSeihinInfo objWorkGroupSeihinInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "WorkGroupSeihinInfo":
                            {
                                objWorkGroupSeihinInfo = new typ.WorkGroupSeihinInfo();
                                vcolWorkGroupSeihinInfo.Add(objWorkGroupSeihinInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objWorkGroupSeihinInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objWorkGroupSeihinInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "WorkGroupID":
                            {
                                objWorkGroupSeihinInfo.WorkGroupID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objWorkGroupSeihinInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "SeihinID":
                            {
                                objWorkGroupSeihinInfo.SeihinID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "WorkOrder":
                            {
                                objWorkGroupSeihinInfo.WorkOrder = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 出荷グループ製品情報のXML読み込み
        //
        // 引き数　　: vobjReader                    - in XmlReader
        // 　　　　　: vcolShippingGroupSeihinInfo   - i/o 出荷グループ製品情報
        //
        // 備考　　　: 2020/ 6/19 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 出荷グループ製品情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolShippingGroupSeihinInfo">出荷グループ製品情報</param>
        private static void msubRead_ShippingGroupSeihinInfoData(XmlReader vobjReader, ref List<zPMxData.typ.ShippingGroupSeihinInfo> vcolShippingGroupSeihinInfo)
        {
            zPMxData.typ.ShippingGroupSeihinInfo objShippingGroupSeihinInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "ShippingGroupSeihinInfo":
                            {
                                objShippingGroupSeihinInfo = new typ.ShippingGroupSeihinInfo();
                                vcolShippingGroupSeihinInfo.Add(objShippingGroupSeihinInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objShippingGroupSeihinInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objShippingGroupSeihinInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "ShippingGroupID":
                            {
                                objShippingGroupSeihinInfo.ShippingGroupID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objShippingGroupSeihinInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "SeihinID":
                            {
                                objShippingGroupSeihinInfo.SeihinID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 材料グループ部材情報のXML読み込み
        //
        // 引き数　　: vobjReader                - in XmlReader
        // 　　　　　: vcolZairyoGroupBuzaiInfo  - i/o 材料グループ部材情報
        //
        // 備考　　　: 2020/ 6/19 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 材料グループ部材情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolZairyoGroupBuzaiInfo">材料グループ部材情報</param>
        private static void msubRead_ZairyoGroupBuzaiInfoData(XmlReader vobjReader, ref List<zPMxData.typ.ZairyoGroupBuzaiInfo> vcolZairyoGroupBuzaiInfo)
        {
            zPMxData.typ.ZairyoGroupBuzaiInfo objZairyoGroupBuzaiInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "ZairyoGroupBuzaiInfo":
                            {
                                objZairyoGroupBuzaiInfo = new typ.ZairyoGroupBuzaiInfo();
                                vcolZairyoGroupBuzaiInfo.Add(objZairyoGroupBuzaiInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objZairyoGroupBuzaiInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objZairyoGroupBuzaiInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "ZairyoGroupID":
                            {
                                objZairyoGroupBuzaiInfo.ZairyoGroupID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objZairyoGroupBuzaiInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "BuzaiID":
                            {
                                objZairyoGroupBuzaiInfo.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 製作グループ名称のXML読み込み
        //
        // 引き数　　: vobjReader            - in XmlReader
        // 　　　　　: vcolWorkGroupNameInfo - i/o 製作グループ名称
        //
        // 備考　　　: 2020/ 6/19 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 製作グループ名称のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolWorkGroupNameInfo">製作グループ名称</param>
        private static void msubRead_WorkGroupNameInfo(XmlReader vobjReader, ref List<zPMxData.typ.WorkGroupNameInfo> vcolWorkGroupNameInfo)
        {
            zPMxData.typ.WorkGroupNameInfo objWorkGroupNameInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "WorkGroupNameInfo":
                            {
                                objWorkGroupNameInfo = new typ.WorkGroupNameInfo();
                                vcolWorkGroupNameInfo.Add(objWorkGroupNameInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objWorkGroupNameInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objWorkGroupNameInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "WorkGroupID":
                            {
                                objWorkGroupNameInfo.WorkGroupID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Name":
                            {
                                objWorkGroupNameInfo.Name = vobjReader.ReadElementContentAsString();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 切り欠き図形のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: vcolNotchFig  - i/o 切り欠き図形
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 切り欠き図形のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolNotchFig">切り欠き図形</param>
        private static void msubRead_NotchFigData(XmlReader vobjReader, ref List<zPMxData.typ.NotchFig> vcolNotchFig)
        {
            zPMxData.typ.NotchFig objNotchFig = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "NotchFig":
                            {
                                objNotchFig = new typ.NotchFig();
                                vcolNotchFig.Add(objNotchFig);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objNotchFig.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objNotchFig.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objNotchFig.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BuzaiID":
                            {
                                objNotchFig.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "NotchID":
                            {
                                objNotchFig.NotchID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Figure2DKind":
                            {
                                objNotchFig.Figure2DKind = zPMxCom.Conv_StringToEnum<enm.Figure2DKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objNotchFig.Ps);
                            }
                            break;

                        case "Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objNotchFig.Pe);
                            }
                            break;

                        case "Pc":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objNotchFig.Pc);
                            }
                            break;

                        case "LPos":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objNotchFig.LPos);
                            }
                            break;

                        case "SPos":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objNotchFig.SPos);
                            }
                            break;

                        case "Direction":
                            {
                                objNotchFig.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "R":
                            {
                                objNotchFig.R = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 構成材料情報のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: vcolComponent - i/o 構成材料情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 構成材料情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolComponent">構成材料情報</param>
        private static void msubRead_Components(XmlReader vobjReader, ref List<zPMxData.typ.ComponentInfo> vcolComponent)
        {
            //zPMxData.typ.ComponentInfo objComponentInfo = null;

            //while (!(vobjReader.EOF))
            //{
            //    if (vobjReader.NodeType == XmlNodeType.Element)
            //    {
            //        switch (vobjReader.LocalName)
            //        {
            //            case "ComponentInfo":
            //                {
            //                    objComponentInfo = new typ.ComponentInfo();
            //                    vcolComponent.Add(objComponentInfo);

            //                    vobjReader.Read();
            //                }
            //                break;

            //            case "FabID":
            //                {
            //                    objComponentInfo.FabID = vobjReader.ReadElementContentAsInt();
            //                }
            //                break;

            //            case "KoujiID":
            //                {
            //                    objComponentInfo.KoujiID = vobjReader.ReadElementContentAsInt();
            //                }
            //                break;

            //            case "Flag":
            //                {
            //                    objComponentInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
            //                }
            //                break;

            //            case "BaseKind":
            //                {
            //                    objComponentInfo.BaseKind = zPMxCom.Conv_StringToEnum<enm.ComponentBaseKind>(vobjReader.ReadElementContentAsString());
            //                }
            //                break;

            //            case "BaseID":
            //                {
            //                    objComponentInfo.BaseID = vobjReader.ReadElementContentAsInt();
            //                }
            //                break;

            //            case "ID":
            //                {
            //                    objComponentInfo.ID = vobjReader.ReadElementContentAsInt();
            //                }
            //                break;

            //            case "Kind":
            //                {
            //                    objComponentInfo.Kind = zPMxCom.Conv_StringToEnum<enm.ComponentKind>(vobjReader.ReadElementContentAsString());
            //                }
            //                break;

            //            case "ConInfoBuzai":
            //                {
            //                    zPMxData.typ.ConInfoBuzai objConInfoBuzai;

            //                    msubRead_ConInfoBuzai(vobjReader.ReadSubtree(), out objConInfoBuzai);

            //                    objComponentInfo.ConInfo = objConInfoBuzai;
            //                }
            //                break;

            //            case "ConInfoKataita":
            //                {
            //                    zPMxData.typ.ConInfoKataita objConInfoKataita;

            //                    msubRead_ConInfoKataita(vobjReader.ReadSubtree(), out objConInfoKataita);

            //                    objComponentInfo.ConInfo = objConInfoKataita;
            //                }
            //                break;

            //            case "ConInfoBuhin":
            //                {
            //                    zPMxData.typ.ConInfoBuhin objConInfoBuhin;

            //                    msubRead_ConInfoBuhin(vobjReader.ReadSubtree(), out objConInfoBuhin);

            //                    objComponentInfo.ConInfo = objConInfoBuhin;
            //                }
            //                break;

            //            default:
            //                {
            //                    vobjReader.Read();
            //                }
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        vobjReader.Read();
            //    }
            //}

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "ComponentInfo":
                            {
                                zPMxData.typ.ComponentInfo objComponentInfo;

                                msubRead_Component(vobjReader.ReadSubtree(), out objComponentInfo);

                                vcolComponent.Add(objComponentInfo);
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 構成材料情報のXML読み込み
        //
        // 引き数　　: vobjReader        - in XmlReader
        // 　　　　　: robjComponentInfo - out 構成材料情報
        //
        // 備考　　　: 2020/ 6/19 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 構成材料情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjComponentInfo">構成材料情報</param>
        private static void msubRead_Component(XmlReader vobjReader, out zPMxData.typ.ComponentInfo robjComponentInfo)
        {
            robjComponentInfo = new typ.ComponentInfo();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "FabID":
                            {
                                robjComponentInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                robjComponentInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                robjComponentInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BaseKind":
                            {
                                robjComponentInfo.BaseKind = zPMxCom.Conv_StringToEnum<enm.ComponentBaseKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BaseID":
                            {
                                robjComponentInfo.BaseID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ID":
                            {
                                robjComponentInfo.ID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Kind":
                            {
                                robjComponentInfo.Kind = zPMxCom.Conv_StringToEnum<enm.ComponentKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "ConInfoBuzai":
                            {
                                zPMxData.typ.ConInfoBuzai objConInfoBuzai;

                                msubRead_ConInfoBuzai(vobjReader.ReadSubtree(), out objConInfoBuzai);

                                robjComponentInfo.ConInfo = objConInfoBuzai;
                            }
                            break;

                        case "ConInfoKataita":
                            {
                                zPMxData.typ.ConInfoKataita objConInfoKataita;

                                msubRead_ConInfoKataita(vobjReader.ReadSubtree(), out objConInfoKataita);

                                robjComponentInfo.ConInfo = objConInfoKataita;
                            }
                            break;

                        case "ConInfoBuhin":
                            {
                                zPMxData.typ.ConInfoBuhin objConInfoBuhin;

                                msubRead_ConInfoBuhin(vobjReader.ReadSubtree(), out objConInfoBuhin);

                                robjComponentInfo.ConInfo = objConInfoBuhin;
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 部材接続情報のXML読み込み
        //
        // 引き数　　: vobjReader        - in XmlReader
        // 　　　　　: robjConInfoBuzai  - out 部材接続情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 部材接続情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjConInfoBuzai">部材接続情報</param>
        private static void msubRead_ConInfoBuzai(XmlReader vobjReader, out zPMxData.typ.ConInfoBuzai robjConInfoBuzai)
        {
            robjConInfoBuzai = new typ.ConInfoBuzai();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "BuzaiID":
                            {
                                robjConInfoBuzai.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Type":
                            {
                                robjConInfoBuzai.Type = zPMxCom.Conv_StringToEnum<enm.BuzaiType>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "DataID":
                            {
                                robjConInfoBuzai.DataID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "PartsNo":
                            {
                                robjConInfoBuzai.PartsNo = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Code":
                            {
                                robjConInfoBuzai.Code = vobjReader.ReadElementContentAsLong();
                            }
                            break;

                        case "WeldInfoData":
                            {
                                if (vobjReader.IsEmptyElement == true)
                                {
                                    vobjReader.Read();
                                }
                                else
                                {
                                    msubRead_WeldInfoData(vobjReader.ReadSubtree(), ref robjConInfoBuzai.WeldInfo);
                                }
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 板接続情報のXML読み込み
        //
        // 引き数　　: vobjReader            - in XmlReader
        // 　　　　　: robjConInfoKataita    - out 板接続情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 板接続情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjConInfoKataita">板接続情報</param>
        private static void msubRead_ConInfoKataita(XmlReader vobjReader, out zPMxData.typ.ConInfoKataita robjConInfoKataita)
        {
            robjConInfoKataita = new typ.ConInfoKataita();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "KataitaID":
                            {
                                robjConInfoKataita.KataitaID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "PartsData":
                            {
                                if (vobjReader.IsEmptyElement == true)
                                {
                                    vobjReader.Read();
                                }
                                else
                                {
                                    msubRead_KataitaParts(vobjReader.ReadSubtree(), ref robjConInfoKataita.Parts);
                                }
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 部品接続情報のXML読み込み
        //
        // 引き数　　: vobjReader        - in XmlReader
        // 　　　　　: robjConInfoBuhin  - out 部品接続情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 部品接続情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjConInfoBuhin">部品接続情報</param>
        private static void msubRead_ConInfoBuhin(XmlReader vobjReader, out zPMxData.typ.ConInfoBuhin robjConInfoBuhin)
        {
            robjConInfoBuhin = new typ.ConInfoBuhin();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "BuhinID":
                            {
                                robjConInfoBuhin.BuhinID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "CoordKind":
                            {
                                robjConInfoBuhin.CoordKind = zPMxCom.Conv_StringToEnum<enm.CoordKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "Coord":
                            {
                                typ.Coord objCoord;

                                msubRead_Coord(vobjReader.ReadSubtree(), out objCoord);

                                robjConInfoBuhin.Coord = objCoord;
                            }
                            break;

                        case "CoordArch":
                            {
                                typ.CoordArch objCoordArch;

                                msubRead_CoordArch(vobjReader.ReadSubtree(), out objCoordArch);

                                robjConInfoBuhin.Coord = objCoordArch;
                            }
                            break;

                        case "WeldInfoData":
                            {
                                if (vobjReader.IsEmptyElement == true)
                                {
                                    vobjReader.Read();
                                }
                                else
                                {
                                    msubRead_WeldInfoData(vobjReader.ReadSubtree(), ref robjConInfoBuhin.WeldInfo);
                                }
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 板構成データ接続情報のXML読み込み
        //
        // 引き数　　: vobjReader        - in XmlReader
        // 　　　　　: vcolKataitaParts  - i/o 板構成データ接続情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 板構成データ接続情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolKataitaParts">板構成データ接続情報</param>
        private static void msubRead_KataitaParts(XmlReader vobjReader, ref List<zPMxData.typ.KataitaParts> vcolKataitaParts)
        {
            zPMxData.typ.KataitaParts objKataitaParts = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "KataitaParts":
                            {
                                objKataitaParts = new typ.KataitaParts();
                                vcolKataitaParts.Add(objKataitaParts);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objKataitaParts.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objKataitaParts.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objKataitaParts.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "CompID":
                            {
                                objKataitaParts.CompID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Pos3D_0":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objKataitaParts.Pos3D[0]);
                            }
                            break;

                        case "Pos3D_1":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objKataitaParts.Pos3D[1]);
                            }
                            break;

                        case "Pos3D_2":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objKataitaParts.Pos3D[2]);
                            }
                            break;

                        case "SideInfoData":
                            {
                                msubRead_KataitaSideInfoData(vobjReader.ReadSubtree(), ref objKataitaParts.SideInfo);
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 板辺接続情報のXML読み込み
        //
        // 引き数　　: vobjReader            - in XmlReader
        // 　　　　　: vcolKataitaSideInfo   - in 板辺接続情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 板辺接続情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolKataitaSideInfo">板辺接続情報</param>
        private static void msubRead_KataitaSideInfoData(XmlReader vobjReader, ref List<zPMxData.typ.KataitaSideInfo> vcolKataitaSideInfo)
        {
            zPMxData.typ.KataitaSideInfo objKataitaSideInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "KataitaSideInfo":
                            {
                                objKataitaSideInfo = new typ.KataitaSideInfo();
                                vcolKataitaSideInfo.Add(objKataitaSideInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objKataitaSideInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objKataitaSideInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objKataitaSideInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "KataitaID":
                            {
                                objKataitaSideInfo.KataitaID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ConInfoID":
                            {
                                objKataitaSideInfo.ConInfoID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "PartsID":
                            {
                                objKataitaSideInfo.PartsID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ID":
                            {
                                objKataitaSideInfo.ID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ConLine_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objKataitaSideInfo.ConLine.Ps);
                            }
                            break;

                        case "ConLine_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objKataitaSideInfo.ConLine.Pe);
                            }
                            break;

                        case "Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out objKataitaSideInfo.Vector);
                            }
                            break;

                        case "FaceNo":
                            {
                                objKataitaSideInfo.FaceNo = (byte)vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "FaceEx":
                            {
                                objKataitaSideInfo.FaceEx = (byte)vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "WeldInfo":
                            {
                                msubRead_WeldInfo(vobjReader.ReadSubtree(), out objKataitaSideInfo.WeldInfo);
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 溶接情報のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: vcolWeldInfo  - i/o 溶接情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 溶接情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolWeldInfo">溶接情報</param>
        private static void msubRead_WeldInfoData(XmlReader vobjReader, ref List<zPMxData.typ.WeldInfo> vcolWeldInfo)
        {
            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "WeldInfo":
                            {
                                zPMxData.typ.WeldInfo objWeldInfo;

                                msubRead_WeldInfo(vobjReader.ReadSubtree(), out objWeldInfo);

                                vcolWeldInfo.Add(objWeldInfo);
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 溶接情報のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: robjWeldInfo  - out 溶接情報
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 溶接情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjWeldInfo">溶接情報</param>
        private static void msubRead_WeldInfo(XmlReader vobjReader, out zPMxData.typ.WeldInfo robjWeldInfo)
        {
            robjWeldInfo = new typ.WeldInfo();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "FabID":
                            {
                                robjWeldInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                robjWeldInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                robjWeldInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BaseKind":
                            {
                                robjWeldInfo.BaseKind = zPMxCom.Conv_StringToEnum<enm.ComponentBaseKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BaseID":
                            {
                                robjWeldInfo.BaseID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "CompID":
                            {
                                robjWeldInfo.CompID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "BuiIndex":
                            {
                                robjWeldInfo.BuiIndex = zPMxCom.Conv_StringToEnum<zPMxCom.enm.Weld.BuiIndex>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "ElementKind":
                            {
                                robjWeldInfo.ElementKind = zPMxCom.Conv_StringToEnum<enm.ElementKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BasePlateKind":
                            {
                                robjWeldInfo.BasePlateKind = zPMxCom.Conv_StringToEnum<enm.PlateKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "Kind":
                            {
                                robjWeldInfo.Kind = zPMxCom.Conv_StringToEnum<zPMxCom.enm.Weld.Kind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "Side":
                            {
                                robjWeldInfo.Side = zPMxCom.Conv_StringToEnum<zPMxCom.enm.Weld.Side>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "Place":
                            {
                                robjWeldInfo.Place = zPMxCom.Conv_StringToEnum<zPMxCom.enm.Weld.Place>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "TipKind":
                            {
                                robjWeldInfo.TipKind = zPMxCom.Conv_StringToEnum<zPMxCom.enm.Weld.TipKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "WeldAngle1":
                            {
                                robjWeldInfo.WeldAngle1 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WeldAngle2":
                            {
                                robjWeldInfo.WeldAngle2 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WeldDepth1":
                            {
                                robjWeldInfo.WeldDepth1 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WeldDepth2":
                            {
                                robjWeldInfo.WeldDepth2 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "RG":
                            {
                                robjWeldInfo.RG = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WeldLen":
                            {
                                robjWeldInfo.WeldLen = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "UT":
                            {
                                robjWeldInfo.UT = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "BPL_KindID":
                            {
                                robjWeldInfo.BPL_KindID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "BPL_StdID":
                            {
                                robjWeldInfo.BPL_StdID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "BPL_Thick":
                            {
                                robjWeldInfo.BPL_Thick = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "BPL_Width":
                            {
                                robjWeldInfo.BPL_Width = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "BPL_Length":
                            {
                                robjWeldInfo.BPL_Length = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "BPL_Count":
                            {
                                robjWeldInfo.BPL_Count = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ET_KindID":
                            {
                                robjWeldInfo.ET_KindID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ET_StdID":
                            {
                                robjWeldInfo.ET_StdID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "ET_Thick":
                            {
                                robjWeldInfo.ET_Thick = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "ET_Width":
                            {
                                robjWeldInfo.ET_Width = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "ET_Width2":
                            {
                                robjWeldInfo.ET_Width2 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "ET_Length":
                            {
                                robjWeldInfo.ET_Length = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "ET_Count":
                            {
                                robjWeldInfo.ET_Count = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 端部開先情報のXML読み込み
        //
        // 引き数　　: vobjReader            - in XmlReader
        // 　　　　　: vcolEdgeWeldGroInfo   - i/o 端部開先情報
        //
        // 備考　　　: 2020/ 6/17 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 端部開先情報のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vcolEdgeWeldGroInfo">端部開先情報</param>
        private static void msubRead_WeldGroInfoData(XmlReader vobjReader, ref List<zPMxData.typ.EdgeWeldGroInfo> vcolEdgeWeldGroInfo)
        {
            zPMxData.typ.EdgeWeldGroInfo objEdgeWeldGroInfo = null;

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "WeldGroInfo":
                            {
                                objEdgeWeldGroInfo = new typ.EdgeWeldGroInfo();
                                vcolEdgeWeldGroInfo.Add(objEdgeWeldGroInfo);

                                vobjReader.Read();
                            }
                            break;

                        case "FabID":
                            {
                                objEdgeWeldGroInfo.FabID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "KoujiID":
                            {
                                objEdgeWeldGroInfo.KoujiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Flag":
                            {
                                objEdgeWeldGroInfo.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "BuzaiID":
                            {
                                objEdgeWeldGroInfo.BuzaiID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "SubID":
                            {
                                objEdgeWeldGroInfo.SubID = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "TipKind":
                            {
                                objEdgeWeldGroInfo.TipKind = zPMxCom.Conv_StringToEnum<zPMxCom.enm.Weld.TipKind>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "WeldAngle1":
                            {
                                objEdgeWeldGroInfo.WeldAngle1 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WeldAngle2":
                            {
                                objEdgeWeldGroInfo.WeldAngle2 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WeldDepth1":
                            {
                                objEdgeWeldGroInfo.WeldDepth1 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WeldDepth2":
                            {
                                objEdgeWeldGroInfo.WeldDepth2 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "RG":
                            {
                                objEdgeWeldGroInfo.RG = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: ３Ｄ構造のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: robjCoord     - out ３Ｄ構造
        //
        // 備考　　　: 2020/ 6/17 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ３Ｄ構造のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjCoord">３Ｄ構造</param>
        private static void msubRead_Coord(XmlReader vobjReader, out zPMxData.typ.Coord robjCoord)
        {
            robjCoord = new typ.Coord();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "Core_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.Core.Ps);
                            }
                            break;

                        case "Core_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.Core.Pe);
                            }
                            break;

                        case "Center_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.Center.Ps);
                            }
                            break;

                        case "Center_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.Center.Pe);
                            }
                            break;

                        case "FrameLU_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameLU.Ps);
                            }
                            break;

                        case "FrameLU_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameLU.Pe);
                            }
                            break;

                        case "FrameRU_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameRU.Ps);
                            }
                            break;

                        case "FrameRU_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameRU.Pe);
                            }
                            break;

                        case "FrameLD_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameLD.Ps);
                            }
                            break;

                        case "FrameLD_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameLD.Pe);
                            }
                            break;

                        case "FrameRD_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameRD.Ps);
                            }
                            break;

                        case "FrameRD_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoord.FrameRD.Pe);
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: ３Ｄ構造アーチ用のXML読み込み
        //
        // 引き数　　: vobjReader        - in XmlReader
        // 　　　　　: robjCoordArch     - out ３Ｄ構造アーチ用
        //
        // 備考　　　: 2020/ 6/17 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ３Ｄ構造アーチ用のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjCoordArch">３Ｄ構造アーチ用</param>
        private static void msubRead_CoordArch(XmlReader vobjReader, out zPMxData.typ.CoordArch robjCoordArch)
        {
            robjCoordArch = new typ.CoordArch();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "Core_Pc":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Core.Pc);
                            }
                            break;

                        case "Core_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Core.Ps);
                            }
                            break;

                        case "Core_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Core.Pe);
                            }
                            break;

                        case "Core_Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Core.Vector);
                            }
                            break;

                        case "Core_R":
                            {
                                robjCoordArch.Core.R = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Core_Direction":
                            {
                                robjCoordArch.Core.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "Center_Pc":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Center.Pc);
                            }
                            break;

                        case "Center_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Center.Ps);
                            }
                            break;

                        case "Center_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Center.Pe);
                            }
                            break;

                        case "Center_Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.Center.Vector);
                            }
                            break;

                        case "Center_R":
                            {
                                robjCoordArch.Center.R = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Center_Direction":
                            {
                                robjCoordArch.Center.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "FrameLU_Pc":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLU.Pc);
                            }
                            break;

                        case "FrameLU_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLU.Ps);
                            }
                            break;

                        case "FrameLU_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLU.Pe);
                            }
                            break;

                        case "FrameLU_Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLU.Vector);
                            }
                            break;

                        case "FrameLU_R":
                            {
                                robjCoordArch.FrameLU.R = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "FrameLU_Direction":
                            {
                                robjCoordArch.FrameLU.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "FrameRU_Pc":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRU.Pc);
                            }
                            break;

                        case "FrameRU_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRU.Ps);
                            }
                            break;

                        case "FrameRU_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRU.Pe);
                            }
                            break;

                        case "FrameRU_Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRU.Vector);
                            }
                            break;

                        case "FrameRU_R":
                            {
                                robjCoordArch.FrameRU.R = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "FrameRU_Direction":
                            {
                                robjCoordArch.FrameRU.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "FrameLD_Pc":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLD.Pc);
                            }
                            break;

                        case "FrameLD_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLD.Ps);
                            }
                            break;

                        case "FrameLD_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLD.Pe);
                            }
                            break;

                        case "FrameLD_Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameLD.Vector);
                            }
                            break;

                        case "FrameLD_R":
                            {
                                robjCoordArch.FrameLD.R = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "FrameLD_Direction":
                            {
                                robjCoordArch.FrameLD.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "FrameRD_Pc":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRD.Pc);
                            }
                            break;

                        case "FrameRD_Ps":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRD.Ps);
                            }
                            break;

                        case "FrameRD_Pe":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRD.Pe);
                            }
                            break;

                        case "FrameRD_Vector":
                            {
                                msubRead_Point3D(vobjReader.ReadSubtree(), out robjCoordArch.FrameRD.Vector);
                            }
                            break;

                        case "FrameRD_R":
                            {
                                robjCoordArch.FrameRD.R = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "FrameRD_Direction":
                            {
                                robjCoordArch.FrameRD.Direction = zPMxCom.Conv_StringToEnum<zPMxCom.typ.Arc.enm.ArcDirection>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 部材構造のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: robjMaterial  - out 部材構造
        //
        // 備考　　　: 2020/ 6/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 部材構造のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="robjMaterial">部材構造</param>
        private static void msubRead_Material(XmlReader vobjReader, out zPMxCom.typ.Material robjMaterial)
        {
            robjMaterial = new zPMxCom.typ.Material();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "Kind":
                            {
                                robjMaterial.Kind = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "Shape":
                            {
                                robjMaterial.Shape = zPMxCom.Conv_StringToEnum<zPMxCom.enm.Shape>(vobjReader.ReadElementContentAsString());
                            }
                            break;

                        case "WH":
                            {
                                robjMaterial.WH = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "FH":
                            {
                                robjMaterial.FH = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "WT":
                            {
                                robjMaterial.WT = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "FT":
                            {
                                robjMaterial.FT = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Size":
                            {
                                robjMaterial.Size = vobjReader.ReadElementContentAsString();
                            }
                            break;

                        case "StdF":
                            {
                                robjMaterial.StdF = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "StdW":
                            {
                                robjMaterial.StdW = vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        case "R1":
                            {
                                robjMaterial.R1 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "R2":
                            {
                                robjMaterial.R2 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "R3":
                            {
                                robjMaterial.R3 = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "UnitMass":
                            {
                                robjMaterial.UnitMass = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "UnitArea":
                            {
                                robjMaterial.UnitArea = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Seam":
                            {
                                robjMaterial.Seam = (byte)vobjReader.ReadElementContentAsInt();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: ３Ｄ座標のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: vstrName      - in 項目名
        // 　　　　　: rusrPoint3D   - out ３Ｄ座標
        //
        // 備考　　　: 2020/ 6/17 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ３Ｄ座標のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vstrName">項目名</param>
        /// <param name="rusrPoint3D">３Ｄ座標</param>
        private static void msubRead_Point3D(XmlReader vobjReader, out zPMxCom.typ.Point3D rusrPoint3D)
        {
            rusrPoint3D = new zPMxCom.typ.Point3D();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "X":
                            {
                                rusrPoint3D.X = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Y":
                            {
                                rusrPoint3D.Y = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Z":
                            {
                                rusrPoint3D.Z = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: ２Ｄ座標データ読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: vstrName      - in 項目名
        // 　　　　　: rcolPoint     - i/o ２Ｄ座標データ
        //
        // 備考　　　: 2020/ 6/22 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ２Ｄ座標データ読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vstrName">項目名</param>
        /// <param name="rcolPoint">２Ｄ座標データ</param>
        private static void msubRead_PointData(XmlReader vobjReader, string vstrName, ref List<zPMxCom.typ.Point> rcolPoint)
        {
            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    if (vobjReader.LocalName == vstrName)
                    {
                        zPMxCom.typ.Point usrPoint;

                        msubRead_Point(vobjReader.ReadSubtree(), out usrPoint);

                        rcolPoint.Add(usrPoint);
                    }
                    else
                    {
                        vobjReader.Read();
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: ２Ｄ座標のXML読み込み
        //
        // 引き数　　: vobjReader    - in XmlReader
        // 　　　　　: vstrName      - in 項目名
        // 　　　　　: rusrPoint     - out ２Ｄ座標
        //
        // 備考　　　: 2020/ 6/17 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// ２Ｄ座標のXML読み込み
        /// </summary>
        /// <param name="vobjReader">XmlReader</param>
        /// <param name="vstrName">項目名</param>
        /// <param name="rusrPoint">２Ｄ座標</param>
        private static void msubRead_Point(XmlReader vobjReader, out zPMxCom.typ.Point rusrPoint)
        {
            rusrPoint = new zPMxCom.typ.Point();

            while (!(vobjReader.EOF))
            {
                if (vobjReader.NodeType == XmlNodeType.Element)
                {
                    switch (vobjReader.LocalName)
                    {
                        case "X":
                            {
                                rusrPoint.X = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        case "Y":
                            {
                                rusrPoint.Y = vobjReader.ReadElementContentAsDouble();
                            }
                            break;

                        default:
                            {
                                vobjReader.Read();
                            }
                            break;
                    }
                }
                else
                {
                    vobjReader.Read();
                }
            }
        }
    }
}
