using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMx
{
    //-------------------------------------------------------------------------
    // Title   : 生産管理システム共通クラス
    // Date    : 2020/ 5/ 1
    // Author  : 金子　淳哉
    // History :
    //-------------------------------------------------------------------------
    /// <summary>
    /// 生産管理システム共通クラス
    /// </summary>
    public class zPMxCom
    {
        //---------------------------------------------------------------------
        // Title   : 列挙型 格納クラス
        // Date    : 2020/ 5/ 1
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 列挙型 格納クラス
        /// </summary>
        public class enm
        {
            //-----------------------------------------------------------------
            // Title   : データの状態
            // History : 2020/ 5/ 1 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// データの状態
            /// </summary>
            public enum DataFlag
            {
                /// <summary>
                /// 新規追加
                /// </summary>
                Added = 0,

                /// <summary>
                /// 登録済
                /// </summary>
                Registered = 1,

                /// <summary>
                /// 編集
                /// </summary>
                Edited = 2,

                /// <summary>
                /// 削除
                /// </summary>
                Deleted = 3,
            }

            //-----------------------------------------------------------------
            // Title   : 形状
            // History : 2020/ 4/20 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 形状
            /// </summary>
            public enum Shape
            {
                /// <summary>H</summary>
                H = 0,

                /// <summary>BH</summary>
                BH = 1,

                /// <summary>I</summary>
                I = 2,

                /// <summary>CT</summary>
                CT = 3,

                /// <summary>BT</summary>
                BT = 4,

                /// <summary>コラム</summary>
                Colu = 5,

                /// <summary>B.BOX</summary>
                BBox = 6,

                /// <summary>パイプ</summary>
                Pipe = 7,

                /// <summary>L</summary>
                L = 8,

                /// <summary>C</summary>
                C = 10,

                /// <summary>[</summary>
                Cha = 13,

                /// <summary>軽[</summary>
                LtCha = 15,

                /// <summary>ﾚｰﾙ</summary>
                Rail = 17,

                /// <summary>T</summary>
                T_T = 18,

                /// <summary>軽L</summary>
                LtL = 19,

                /// <summary>不等辺L</summary>
                UnEqL = 21,

                /// <summary>BL</summary>
                BL = 23,

                /// <summary>B[</summary>
                BCha = 25,

                /// <summary>PL</summary>
                PL = 50,

                /// <summary>FB</summary>
                FB = 51,

                /// <summary>デッキプレート</summary>
                DeckPL = 52,

                /// <summary>ベース</summary>
                Base = 53,

                /// <summary>丸鋼</summary>
                MaruKou = 54,

                /// <summary>鉄筋</summary>
                Tekkin = 55,

                /// <summary>角鋼</summary>
                KakuKou = 56,

                /// <summary>ボルト</summary>
                Bolt = 57,

                /// <summary>ナット</summary>
                Nut = 58,

                /// <summary>アンカーボルト</summary>
                AnchorBolt = 59,

                /// <summary>スタッドジベル</summary>
                Stud = 60,

                /// <summary>HB.BOX</summary>
                HBBOX = 61,

                /// <summary>HB.H</summary>
                HBH = 62,

                /// <summary>HB.R</summary>
                HBR = 63,

                /// <summary>HB.偏心</summary>
                HBHenshin = 64,

                /// <summary>HB.BOLT</summary>
                HBBolt = 65,

                /// <summary>NC.BASE</summary>
                NCBase = 66,

                /// <summary>BASE PACK</summary>
                BasePack = 67,

                /// <summary>U BOND</summary>
                UBond = 68,

                /// <summary>SRCHB.X</summary>
                SRCHBX = 69,

                /// <summary>SRCHB.T</summary>
                SRCHBT = 70,

                /// <summary>SRCHB.LR</summary>
                SRCHBLR = 71,

                /// <summary>SRCHB.LL</summary>
                SRCHBLL = 72,

                /// <summary>SRCHB.SRCH</summary>
                SRCHBSRCH = 73,

                /// <summary>ターンバックル</summary>
                TurnBuckle = 74,

                /// <summary>ブレースシート</summary>
                BraceSheet = 75,

                /// <summary>羽子板</summary>
                Hagoita = 76,

                /// <summary>B.PACK NT</summary>
                BPackNT = 77,

                /// <summary>SHB.BOX</summary>
                SHBBox = 78,

                /// <summary>SHB.H</summary>
                SHBH = 79,

                /// <summary>SHB.R</summary>
                SHBR = 80,

                /// <summary>SHB.偏心</summary>
                SHBHenshin = 81,

                /// <summary>SHB.BOLT</summary>
                SHBBolt = 82,

                /// <summary>NC.BASEφ</summary>
                NCBasePipe = 83,

                /// <summary>JUST BASE</summary>
                JustBase = 84,

                /// <summary>SRCSHB.X</summary>
                SRCSHBX = 85,

                /// <summary>SRCSHB.T</summary>
                SRCSHBT = 86,

                /// <summary>SRCSHB.LL</summary>
                SRCSHBLL = 87,

                /// <summary>SRCSHB.LR</summary>
                SRCSHBLR = 88,

                /// <summary>SRCSHB.H</summary>
                SRCSHBH = 89,

                /// <summary>その他</summary>
                Etc = 90,

                /// <summary>その他形鋼</summary>
                EtcShapes = 91,

                /// <summary>アンカーボルト L型</summary>
                AnchorBtL = 92,

                /// <summary>アンカーボルト S型</summary>
                AnchorBtS = 93,

                /// <summary>SHB.2偏心</summary>
                SHB2Henshin = 94,

                /// <summary>HB-ECO.BOX</summary>
                HBEcoBox = 95,

                /// <summary>IS BASE</summary>
                ISBase = 96,

                /// <summary>NC.B EX</summary>
                NCBEX = 97,

                /// <summary>NC.B EXφ</summary>
                NCBEXPH = 98,

                /// <summary>JISブレース</summary>
                JISBrace = 99,

                /// <summary>丸鋼ブレース</summary>
                RBBrace = 100,

                /// <summary>平丸ワッシャー</summary>
                HiraWasher = 101,

                /// <summary>角丸ワッシャー</summary>
                KakuWasher = 102,

                /// <summary>半球キャップ</summary>
                SemirndCap = 103,

                /// <summary>Eベース</summary>
                EBase = 104,

                /// <summary>アンカーボルト I型</summary>
                AnchorBtI = 105,

                /// <summary>既製品ピース</summary>
                RMPiece = 106,

                /// <summary>ハイリング</summary>
                HiRing = 107,

                /// <summary>HB-ECO.R</summary>
                HBEcoR = 108,

                /// <summary>既製品ピース1(L形状)</summary>
                RMPiece1 = 109,

                /// <summary>鉄筋コンクリート丸形</summary>
                RCMaru = 110,

                /// <summary>鉄筋コンクリート角形</summary>
                RCKaku = 111,

                /// <summary>クリアベース</summary>
                ClearBase = 112,

                /// <summary>ファブラックス</summary>
                Fabluxe = 113,

                /// <summary>NDコア</summary>
                NDCore = 114,

                /// <summary>フリードーナツ</summary>
                Freedonut = 115,

                /// <summary>OSリング</summary>
                OSRing = 116,

                /// <summary>建方エースEP</summary>
                TatekataAceEP = 117,

                /// <summary>NC.B EX2</summary>
                NCBEX2 = 118,

                /// <summary>NC.B EX2φ</summary>
                NCBEXPH2 = 119,

                /// <summary>ATOMU(既製品エレクションピース)</summary>
                ATOMU = 120,

                /// <summary>ファブラックスDS</summary>
                FabluxeDS = 121,

                /// <summary>鉄人(標準)(既製品エレクションピース)</summary>
                Tetsujin = 122,

                /// <summary>HB-NEO</summary>
                HBNEO = 123,

                /// <summary>NCベースPのコラム形状</summary>
                NCBPColu = 124,

                /// <summary>NCベースPのパイプ形状</summary>
                NCBPPipe = 125,

                /// <summary>EGリング</summary>
                EGRing = 126,

                /// <summary>スマートダイア</summary>
                SmartDia = 127,

                /// <summary>コラムカプラ</summary>
                ColumnCoupler = 128,

                /// <summary>KH-コラムジョイント（既製品仕口）</summary>
                KH_ColumnJoint = 129,

                /// <summary>
                /// E-BASE（ヤマトアパレイユ社製）
                /// <para>※104-Eベース とは別物です。</para>
                /// </summary>
                E_BASE = 130,

                /// <summary>NCベースPのコラム形状のPS</summary>
                NCBPColu_PS = 131,

                /// <summary>NCベースPのパイプ形状のPC</summary>
                NCBPPipe_PC = 132,

                //2019/07/10 - 田中　明
                /// <summary>定着板</summary>
                TeiPlate = 133,

                //2020/01/30 - 田中　明
                /// <summary>フリーベース</summary>
                FreeBase = 134,

                //2020/01/30 - 田中　明
                //スマートベースの形状番号が未対応で決めれないので取りあえずはしばらく重複させないために「500」としておく
                /// <summary>スマートベース</summary>
                SmartBase = 500,
            }

            //-----------------------------------------------------------------
            // Title   : 部材種類
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 部材種類
            /// </summary>
            public enum BuzaiKind
            {
                /// <summary>
                /// 未定義
                /// </summary>
                [attEnumLabel("未定義")]
                Undefined = 0,

                /// <summary>
                /// ダミー
                /// </summary>
                [attEnumLabel("ダミー")]
                Dummy = 1,

                /// <summary>
                /// 本柱
                /// </summary>
                [attEnumLabel("本柱")]
                Column = 2,

                /// <summary>
                /// 間柱
                /// </summary>
                [attEnumLabel("間柱")]
                Post = 3,

                /// <summary>
                /// 大梁
                /// </summary>
                [attEnumLabel("大梁")]
                Girder = 4,

                /// <summary>
                /// 小梁
                /// </summary>
                [attEnumLabel("小梁")]
                Beam = 5,

                /// <summary>
                /// ブラケット
                /// </summary>
                [attEnumLabel("ブラケット")]
                Bracket = 6,

                /// <summary>
                /// ブレース
                /// </summary>
                [attEnumLabel("ブレース")]
                Brace = 7,

                /// <summary>
                /// 胴縁
                /// </summary>
                [attEnumLabel("胴縁")]
                DBC = 8,

                /// <summary>
                /// 母屋
                /// </summary>
                [attEnumLabel("母屋")]
                Moya = 9,

                /// <summary>
                /// ブレースブラケット
                /// </summary>
                [attEnumLabel("ブレースブラケット")]
                BraceBracket = 10,

                /// <summary>
                /// 片持ち梁
                /// </summary>
                [attEnumLabel("片持ち梁")]
                Cantilever = 11,

                /// <summary>
                /// 方杖
                /// </summary>
                [attEnumLabel("方杖")]
                Strut = 12,

                /// <summary>
                /// タイロッド
                /// </summary>
                [attEnumLabel("タイロッド")]
                TieRod = 13,

                /// <summary>
                /// 角パイプフィラー
                /// </summary>
                [attEnumLabel("角パイプフィラー")]
                PipeFiller = 14,

                /// <summary>
                /// かさ上げ材
                /// </summary>
                [attEnumLabel("かさ上げ材")]
                RaiseBz = 15,

                /// <summary>
                /// 折板受け
                /// </summary>
                [attEnumLabel("折板受け")]
                Tight = 16,

                /// <summary>
                /// デッキ受け
                /// </summary>
                [attEnumLabel("デッキ受け")]
                Deck = 17,

                /// <summary>
                /// 仕口単管
                /// </summary>
                [attEnumLabel("仕口単管")]
                Core = 18,
            }

            //-----------------------------------------------------------------
            // Title   : スカラップ
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// スカラップ
            /// </summary>
            public enum WeldScallopKind
            {
                /// <summary>
                /// なし
                /// </summary>
                None = 0,

                /// <summary>
                /// 円弧―円弧
                /// </summary>
                ArcArc = 1,

                /// <summary>
                /// 直線―円弧
                /// </summary>
                LineArc = 2,

                /// <summary>
                /// 円弧―円弧２
                /// </summary>
                ArcArc2 = 3,

                /// <summary>
                /// ノンスカラップ
                /// </summary>
                NonScalop = 4,
            }

            /// <summary>
            /// 溶接
            /// </summary>
            public class Weld
            {
                //-----------------------------------------------------------------
                // Title   : 溶接部位
                // History : 2020/ 4/20 - 金子　淳哉
                //-----------------------------------------------------------------
                /// <summary>
                /// 溶接部位
                /// </summary>
                public enum BuiIndex
                {
                    /// <summary>
                    /// 未定義
                    /// </summary>
                    Undefined = 0,

                    /// <summary>1-通しダイアとブラケット</summary>
                    BktOutDia = 1,

                    /// <summary>2-ブラケットと柱のウェブ接合部</summary>
                    BktColWEB = 2,

                    /// <summary>3-コラム柱と通しダイアの接合部(シャフト側)</summary>
                    ColOutDia = 3,

                    /// <summary>4-仕口ビルド材作成(Ｂ.ＢＯＸ)</summary>
                    BldMakeBox = 4,

                    /// <summary>5-柱ガセット</summary>
                    ColGusset = 5,

                    /// <summary>6-溶接ガセットのフランジ接合部(内ダイア)</summary>
                    BktInDiaGusset = 6,

                    /// <summary>7-柱と内ダイア</summary>
                    ColInDia = 7,

                    /// <summary>8-柱と柱</summary>
                    B_ColCol = 8,

                    /// <summary>9-ビルド材作成(ＢＨ、ＢＴ)</summary>
                    BldMake = 9,

                    /// <summary>10-ビルドブラケットと柱のウェブ接合部</summary>
                    BldBktColWEB = 10,

                    /// <summary>11-ブラケットと柱のフランジ接合部</summary>
                    BktColFLG = 11,

                    /// <summary>12-スタッドジベル(工場)</summary>
                    Stad = 12,

                    /// <summary>13-リブ</summary>
                    Rib = 13,

                    /// <summary>14-Ｈ柱のウェブとベースの接合部</summary>
                    ColBaseWEB = 14,

                    /// <summary>15-Ｈ柱のフランジとベースの接合部</summary>
                    ColBaseFLG = 15,

                    /// <summary>16-フランジとフランジの接合部</summary>
                    GirBktFLG = 16,

                    /// <summary>17-スリーブ補強プレートの溶接</summary>
                    SlbPlate = 17,

                    /// <summary>18-スリーブ管と補強プレートの溶接</summary>
                    SlbTubePlate = 18,

                    /// <summary>19-梁ガセット接合部</summary>
                    GirGusset = 19,

                    /// <summary>20-大梁と小梁の溶接</summary>
                    GirBGirS = 20,

                    /// <summary>21-溶接ガセットのフランジ接合部(通しダイア)</summary>
                    BktOutDiaGusset = 21,

                    /// <summary>22-Ｈ柱の内ダイアのウェブ ピン梁接続</summary>
                    HColInDiaWEB = 22,

                    /// <summary>23-Ｈ柱の内ダイアのフランジ(剛継手)</summary>
                    HColInDiaFLG = 23,

                    /// <summary>24-エレクションピースと柱</summary>
                    ErpCol = 24,

                    /// <summary>25-Ｈ柱の内ダイアのフランジ(強軸接続)</summary>
                    HColInDiaFLG2 = 25,

                    /// <summary>26-縦スチフナ</summary>
                    VStiffener = 26,

                    /// <summary>27-仕口パネル</summary>
                    CorePanel = 27,

                    /// <summary>28-デッキ受け(梁)</summary>
                    DeckSPLGir = 28,

                    /// <summary>29-デッキ受け(柱)</summary>
                    DeckSPLCol = 29,

                    /// <summary>30-ハイステージ</summary>
                    HighStage = 30,

                    /// <summary>31-カンザシ(組み合わせ)のPLと鉄筋の溶接部</summary>
                    KanzashiCmbR = 31,

                    /// <summary>32-カンザシと梁の溶接部</summary>
                    KanzashiSmpS = 32,

                    /// <summary>33-カンザシ(丸鋼、鉄筋)と梁の溶接部</summary>
                    KanzashiSmpR = 33,

                    /// <summary>34-バンド</summary>
                    Band = 34,

                    /// <summary>35-コラム柱と通しダイアの接合部(仕口側)</summary>
                    ColOutDia2 = 35,

                    /// <summary>36-フィラープレート</summary>
                    Filler = 36,

                    /// <summary>37-羽子板と鉄筋の溶接</summary>
                    HagoTekkin = 37,

                    /// <summary>38-亀の甲の溶接</summary>
                    Kame = 38,

                    /// <summary>39-はさみ板の溶接</summary>
                    Hasami = 39,

                    /// <summary>40-隅肉溶接</summary>
                    F = 40,

                    /// <summary>41-Ｈ柱のウェブと通しダイアの接合部</summary>
                    ColCoreWEB = 41,

                    /// <summary>42-Ｈ柱のフランジと通しダイアの接合部</summary>
                    ColCoreFLG = 42,

                    /// <summary>43-梁とブラケットのウェブ接合部</summary>
                    GdrBktWEB = 43,

                    /// <summary>44-大梁(ウェブ)と小梁の溶接</summary>
                    GirBGirSWeb = 44,

                    /// <summary>45-柱トップダイア(溶接梁が付かないダイア)の溶接</summary>
                    ColTopDia = 45,

                    /// <summary>46-スタッドジベル付Ｈ柱ウェブとベースの接合部</summary>
                    ColBaseWEBStad = 46,

                    /// <summary>47-スタッドジベル付Ｈ柱フランジとベースの接合部</summary>
                    ColBaseFLGStad = 47,

                    /// <summary>48-コラム柱とベースの接合部</summary>
                    ClmColBase = 48,

                    /// <summary>49-スタッドジベル付コラム柱とベースの接合部</summary>
                    ClmColBaseStad = 49,

                    /// <summary>50-合掌突合せのフランジ溶接</summary>
                    FIJoin = 50,

                    /// <summary>51-合掌突合せのウェブ溶接</summary>
                    WIJoin = 51,

                    /// <summary>52-Ｈ柱の内ダイアのフランジ(弱軸接続)</summary>
                    HColInDiaFLG3 = 52,

                    /// <summary>53-板継ぎのウェブ</summary>
                    ThickJointWEB = 53,

                    /// <summary>54-コラム補強板</summary>
                    ColInDiaFLGTop = 54,

                    /// <summary>55-縦スチフナー上側(最上階)</summary>
                    VStiffenerTop = 55,

                    /// <summary>56-Tガセット</summary>
                    TGusset = 56,

                    /// <summary>57-梁ガセットフランジ接合部</summary>
                    GirGussetF = 57,

                    /// <summary>58-ブレースシート</summary>
                    BraceSheet = 58,

                    /// <summary>59-スチフナー(強軸フランジ)</summary>
                    StiffenerF1 = 59,

                    /// <summary>60-スチフナー(弱軸フランジ)</summary>
                    StiffenerF2 = 60,

                    /// <summary>61-スチフナー(フランジ)</summary>
                    StiffenerF3 = 61,

                    /// <summary>62-スチフナー(ウェブ)</summary>
                    StiffenerW = 62,

                    /// <summary>63-梁に間柱接続のスチフナー(強軸フランジ)</summary>
                    StiffenerPostF1 = 63,

                    /// <summary>64-梁に間柱接続のスチフナー(フランジ)</summary>
                    StiffenerPostF2 = 64,

                    /// <summary>65-梁に間柱接続のスチフナー(ウェブ)</summary>
                    StiffenerPostW = 65,

                    /// <summary>66-梁フランジの溶接</summary>
                    GirFLG = 66,

                    /// <summary>67-梁ウェブの溶接</summary>
                    GirWeb = 67,

                    /// <summary>68-裏当て金の溶接</summary>
                    BPlate = 68,

                    /// <summary>69-H・コラム以外の溶接</summary>
                    ETC_H_Colu = 69,

                    /// <summary>70-板継ぎのフランジ</summary>
                    ThickJointFLG = 70,

                    /// <summary>71-溶接ガセットのフランジ接合部(柱)</summary>
                    BktColGusset = 71,

                    /// <summary>72-ハンチ三角板フランジ接合部</summary>
                    HanceDeltaFLG = 72,

                    /// <summary>73-ハンチ三角板ウェブ接合部</summary>
                    HanceDeltaWEB = 73,

                    /// <summary>74-ハンチ展開材フランジ接合部</summary>
                    HanceBHPL_FLG = 74,

                    /// <summary>75-かさ上げ材の溶接</summary>
                    RaiseBz = 75,

                    /// <summary>76-かさ上げ継板の溶接</summary>
                    RaiseBzPL = 76,

                    /// <summary>77-十字継手とシート＋WEBスプライスの溶接</summary>
                    CrossWEBSpl = 77,

                    /// <summary>78-サイドプレートの溶接</summary>
                    SidePlate = 78,

                    /// <summary>79-ネットフックV型の溶接</summary>
                    NetHook_V = 79,

                    /// <summary>80-ネットフックボルトの溶接</summary>
                    NetHook_Bolt = 80,

                    /// <summary>81-吊ピースの溶接</summary>
                    HangPiece = 81,

                    /// <summary>82-建入直しピースの溶接</summary>
                    BuiltPiece = 82,

                    /// <summary>83-親綱ピースの溶接</summary>
                    Lifeline = 83,

                    /// <summary>84-梁下がり止めの溶接</summary>
                    FallStop = 84,

                    /// <summary>85-スタッドジベル(現場)</summary>
                    Stad_Spot = 85,

                    /// <summary>86-合掌プレートとガセットの溶接</summary>
                    JointGusset = 86,

                    /// <summary>87-ファブラックスと梁ウェブの溶接</summary>
                    fabluxe_GirWeb = 87,

                    /// <summary>88-ファブラックスと梁フランジの溶接</summary>
                    fabluxe_GirFra = 88,

                    /// <summary>89-ファブラックスと柱の溶接</summary>
                    fabluxe_Col = 89,

                    /// <summary>90-ファブラックス最上部鋼板の溶接</summary>
                    fabluxe_Plate = 90,

                    /// <summary>87-NDコアと梁ウェブの溶接</summary>
                    NDCore_GirWeb = 91,

                    /// <summary>88-NDコアと梁フランジの溶接</summary>
                    NDCore_GirFra = 92,

                    /// <summary>89-NDコアと柱の溶接</summary>
                    NDCore_Col = 93,

                    /// <summary>90-NDコア最上部鋼板の溶接</summary>
                    NDCore_Plate = 94,

                    /// <summary>45-H柱のフランジとトップダイア(溶接梁が付かないダイア)の溶接</summary>
                    ColTopDia_H_FRG = 95,

                    /// <summary>96-ウェブとウェブの接合部</summary>
                    WEBToWEB = 96,

                    /// <summary>97-特殊部品の溶接</summary>
                    PartsEx = 97,

                    /// <summary>23-Ｈ柱の内ダイアのフランジ(剛継手)</summary>
                    HColInDiaFLG4 = 98,

                    /// <summary>22-梁貫通時の縦スチフナーのウェブの溶接</summary>
                    VStiffenerWEB = 99,

                    /// <summary>22-Ｈ柱の内ダイアのウェブ(弱軸接続)</summary>
                    HColInDiaWEB2 = 100,

                    /// <summary>101-組み柱の接合部</summary>
                    ColKumi1 = 101,

                    /// <summary>102-組み柱の接合部</summary>
                    ColKumi2 = 102,

                    /// <summary>103-付けフランジの溶接</summary>
                    ConFRG = 103,

                    /// <summary>104-塞ぎ材(外側)の溶接</summary>
                    BlindOut = 104,

                    /// <summary>105-塞ぎ材(内側)の溶接</summary>
                    BlindIn = 105,

                    /// <summary>106-リップ補強鋼材の溶接</summary>
                    RipSupport = 106,

                    /// <summary>107-角パイプフィラーの溶接</summary>
                    PipeFiller = 107,

                    /// <summary>108-カバープレートの溶接</summary>
                    CoverPL = 108,

                    /// <summary>109-ビルド材作成(Ｂ.ＢＯＸ)</summary>
                    BldMakeBox_Col = 109,

                    /// <summary>110-エンドプレートの溶接</summary>
                    EndPL = 110,

                    /// <summary>111-B.BOX柱と内ダイア</summary>
                    ColInDiaBBOX = 111,

                    /// <summary>112-ベースリブ(住金)</summary>
                    Rib_Sumikin = 112,

                    /// <summary>113-仕口補強H型金物 リブPLのフランジPLとの溶接</summary>
                    RibF_Sumikin = 113,

                    /// <summary>114-仕口補強H型金物 リブPLのウェブPLとの溶接</summary>
                    RibW_Sumikin = 114,

                    /// <summary>115-内ダイアのフランジPLとの溶接</summary>
                    ColInDiaFPL_Sumikin = 115,

                    /// <summary>116-溶接ガセットのウェブ溶接</summary>
                    WeldGstWeb = 116,

                    /// <summary>117-Ｈ柱の内ダイアのウェブ 溶接梁(弱軸)</summary>
                    HColInDiaWEB3 = 117,

                    /// <summary>118-Ｈ柱の内ダイアのウェブ 溶接梁(強軸)</summary>
                    HColInDiaWEB4 = 118,

                    /// <summary>119-コラムカプラの溶接</summary>
                    ColumnCoupler = 119,

                    /// <summary>120-コラム柱とエレクションピース通しプレートの溶接</summary>
                    ErpColDiaSpot = 120,

                    /// <summary>121-TK金物リブプレートの溶接</summary>
                    TKBaseRib_Sumikin = 121,

                    /// <summary>122-リブ付きスプライスプレートの溶接</summary>
                    RibSplice_Sumikin = 122,

                    /// <summary>123-フランジブレースの補強リブの溶接</summary>
                    RibFLGBrace_Sumikin = 123,

                    /// <summary>124-KHコラムと梁ウェブの溶接</summary>
                    KHCol_GirWeb = 124,

                    /// <summary>125-KHコラムと梁フランジの溶接</summary>
                    KHCol_GirFra = 125,

                    /// <summary>126-KHコラムと柱の溶接</summary>
                    KHCol_Col = 126,

                    /// <summary>127-KHコラム最上部鋼板の溶接</summary>
                    KHCol_Plate = 127,

                    /// <summary>128-ファブラックスと通しダイアの接合部</summary>
                    fabluxeOutDia = 128,

                    /// <summary>3-NDコアと通しダイアの接合部</summary>
                    NDCoreOutDia = 129,

                    /// <summary>3-KHコラムと通しダイアの接合部</summary>
                    KHColOutDia = 130,

                    /// <summary>131-水切りプレートの溶接</summary>
                    Weatherboard = 131,

                    /// <summary>溶接部位の最大数</summary>
                    PartsMax = 132,
                }

                //-----------------------------------------------------------------
                // Title   : 溶接種類
                // History : 2020/ 4/17 - 金子　淳哉
                //-----------------------------------------------------------------
                /// <summary>
                /// 溶接種類
                /// </summary>
                public enum Kind
                {
                    /// <summary>
                    /// 未定義
                    /// </summary>
                    Undefined = 0,

                    /// <summary>
                    /// 突合せ
                    /// </summary>
                    B = 1,

                    /// <summary>
                    /// Ｔ継手
                    /// </summary>
                    T = 2,

                    /// <summary>
                    /// かど継手
                    /// </summary>
                    C = 3,

                    /// <summary>
                    /// ビルド材
                    /// </summary>
                    L = 4,

                    /// <summary>
                    /// 隅肉溶接
                    /// </summary>
                    F = 5,

                    /// <summary>
                    /// フレア溶接
                    /// </summary>
                    R = 6,

                    /// <summary>
                    /// エレクトロ・スラグ溶接
                    /// </summary>
                    E = 7,

                    /// <summary>
                    /// 部分溶け込み－突合せ
                    /// </summary>
                    PB = 8,

                    /// <summary>
                    /// 部分溶け込み－Ｔ継手
                    /// </summary>
                    PT = 9,

                    /// <summary>
                    /// 部分溶け込み－かど継手
                    /// </summary>
                    PC = 10,

                    /// <summary>
                    /// B.BOX－かど継手1
                    /// </summary>
                    BC = 11,

                    /// <summary>
                    /// B.BOX－かど継手2
                    /// </summary>
                    BCS = 12,
                }

                //-----------------------------------------------------------------
                // Title   : 溶接面
                // History : 2020/ 4/17 - 金子　淳哉
                //-----------------------------------------------------------------
                /// <summary>
                /// 溶接面
                /// </summary>
                public enum Side
                {
                    /// <summary>
                    /// 片面
                    /// </summary>
                    One = 0,

                    /// <summary>
                    /// 両面
                    /// </summary>
                    Both = 1,
                }

                //-----------------------------------------------------------------
                // Title   : 開先形状
                // History : 2020/ 4/17 - 金子　淳哉
                //-----------------------------------------------------------------
                /// <summary>
                /// 開先形状
                /// </summary>
                public enum TipKind
                {
                    /// <summary>
                    /// 未定義
                    /// </summary>
                    Undefined = 0,

                    /// <summary>
                    /// Ｉ開先
                    /// </summary>
                    I = 1,

                    /// <summary>
                    /// Ｖ開先
                    /// </summary>
                    V = 2,

                    /// <summary>
                    /// Ｘ開先
                    /// </summary>
                    X = 3,

                    /// <summary>
                    /// Ｌ開先
                    /// </summary>
                    L = 4,

                    /// <summary>
                    /// Ｋ開先
                    /// </summary>
                    K = 5,
                }

                //-----------------------------------------------------------------
                // Title   : 溶接場所
                // History : 2020/ 5/ 8 - 金子　淳哉
                //-----------------------------------------------------------------
                /// <summary>
                /// 溶接場所
                /// </summary>
                public enum Place
                {
                    /// <summary>
                    /// 工場溶接
                    /// </summary>
                    Fact = 0,

                    /// <summary>
                    /// 現場溶接
                    /// </summary>
                    Spot = 1,
                }
            }

            //-----------------------------------------------------------------
            // Title   : 左端部・右端部を定義する列挙体
            // History : 2020/ 3/ 5 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 左端部・右端部を定義する列挙体
            /// </summary>
            public enum EdgePart
            {
                /// <summary>
                /// 左
                /// </summary>
                Left = 0,

                /// <summary>
                /// 右
                /// </summary>
                Right = 1,
            }

            //-----------------------------------------------------------------
            // Title   : REAL4マスター種類
            // History : 2020/ 5/22 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// REAL4マスター種類
            /// </summary>
            public enum R4MstKind
            {
                /// <summary>なし</summary>
                [attEnumLabel("")]
                None = 0,

                /// <summary>柱マスタ</summary>
                [attEnumLabel("柱")]
                Column = 1,

                /// <summary>間柱マスタ</summary>
                [attEnumLabel("間柱")]
                Post = 2,

                /// <summary>ＳＲＣ柱マスタ</summary>
                [attEnumLabel("ＳＲＣ柱")]
                SRCColumn = 3,

                /// <summary>大梁マスタ</summary>
                [attEnumLabel("大梁")]
                Girder = 4,

                /// <summary>小梁マスタ</summary>
                [attEnumLabel("小梁")]
                Beam = 5,

                /// <summary>ベースマスタ</summary>
                [attEnumLabel("ベース")]
                Base = 6,

                /// <summary>継手マスタ</summary>
                [attEnumLabel("継手")]
                Joint = 7,

                /// <summary>スタッドマスタ(廃止)</summary>
                //Stud = 8,

                /// <summary>部品マスタ</summary>
                [attEnumLabel("部品")]
                Parts = 9,

                /// <summary>ブレースマスタ</summary>
                [attEnumLabel("ブレース")]
                Brace = 10,

                /// <summary>柱表入力</summary>
                [attEnumLabel("柱")]
                SheetInput_Col = 11,

                /// <summary>梁表入力</summary>
                [attEnumLabel("梁")]
                SheetInput_Grd = 12,

                /// <summary>間柱表入力</summary>
                [attEnumLabel("間柱")]
                SheetInput_Post = 13,

                /// <summary>小梁表入力</summary>
                [attEnumLabel("小梁")]
                SheetInput_Beam = 14,

                /// <summary>母屋マスタ</summary>
                [attEnumLabel("母屋")]
                Purlin = 15,

                /// <summary>ピースマスタ</summary>
                [attEnumLabel("ピース")]
                Piece = 16,

                /// <summary>スリーブマスタ</summary>
                [attEnumLabel("スリーブ")]
                Sleeve = 17,

                /// <summary>かさ上げマスタ</summary>
                [attEnumLabel("かさ上げ材")]
                RaiseBz = 18,

                /// <summary>デッキ受けマスタ</summary>
                [attEnumLabel("デッキ受け")]
                DeckSubPL = 19,

                /// <summary>仮設金物マスタ</summary>
                [attEnumLabel("仮設金物")]
                TempPiece = 20,

                /// <summary>スタッドマスタ</summary>
                /// <remark>2次部材としてスタッドマスタを追加</remark>
                [attEnumLabel("スタッド")]
                SecStud = 21,

                /// <summary>特殊部品マスタ</summary>
                [attEnumLabel("特殊部品")]
                PartsEx = 22,

                /// <summary>かんざしマスタ</summary>
                [attEnumLabel("カンザシ")]
                Kanzashi = 23,

                /// <summary>RC梁マスタ</summary>
                [attEnumLabel("RC梁")]
                RCBeam = 24,

                /// <summary>RC柱主筋マスタ</summary>
                [attEnumLabel("RC柱主筋")]
                RCColumn = 25,

                /// <summary>RC梁主筋マスタ</summary>
                [attEnumLabel("RC梁主筋")]
                RCGirder = 26,

                /// <summary>開口マスタ</summary>
                [attEnumLabel("開口")]
                PurlinDBCWindow = 27,

                /// <summary>フランジブレース</summary>
                [attEnumLabel("フランジブレース")]
                FLGBrace = 28,
            }
        }//End Class

        //---------------------------------------------------------------------
        // Title   : 構造体 格納クラス
        // Date    : 2020/ 5/ 1
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 構造体 格納クラス
        /// </summary>
        public class typ
        {
            //-------------------------------------------------------------------------
            // Title   : 基本情報
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 基本情報
            /// </summary>
            public class BaseInfo
            {
                /// <summary>
                /// キーID
                /// </summary>
                private KeyID musrKeyID;

                //-Prop----------------------------------------------------------------
                //
                // 機能　　　: 参照/設定
                //
                // 取得値　　: ファブID
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID
                {
                    get { return musrKeyID.FabID; }
                    set { musrKeyID.FabID = value; }
                }

                //-Prop----------------------------------------------------------------
                //
                // 機能　　　: 参照/設定
                //
                // 取得値　　: 工事ID
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 工事ID
                /// </summary>
                public int KoujiID
                {
                    get { return musrKeyID.KoujiID; }
                    set { musrKeyID.KoujiID = value; }
                }

                /// <summary>
                /// 状態
                /// </summary>
                public enm.DataFlag Flag = enm.DataFlag.Added;

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
                public BaseInfo()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vobjOther - in コピー元
                //
                // 備考　　　: 2020/ 4/28 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public BaseInfo(BaseInfo vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.KoujiID = vobjOther.KoujiID;
                    this.Flag = vobjOther.Flag;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
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

                    return this.Equals((BaseInfo)vobjOther);
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(BaseInfo vobjOther)
                {
                    return this.FabID == vobjOther.FabID && this.KoujiID == vobjOther.KoujiID && this.Flag == vobjOther.Flag;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: GetHashCode()のオーバーライド
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// GetHashCode()のオーバーライド
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    return this.musrKeyID.GetHashCode() ^ this.Flag.GetHashCode();
                }

            }//End Class

            //-------------------------------------------------------------------------
            // Title   : キーID（ファブID＋工事ID）
            // Date    : 2020/ 5/19
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// キーID（ファブID＋工事ID）
            /// </summary>
            public struct KeyID : IEquatable<KeyID>
            {
                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 工事ID
                /// </summary>
                public int KoujiID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vintFabID     - in ファブID
                // 　　　　　: vintKoujiID   - in 工事ID
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vintFabID">ファブID</param>
                /// <param name="vintKoujiID">工事ID</param>
                public KeyID(int vintFabID, int vintKoujiID)
                {
                    this.FabID = vintFabID;
                    this.KoujiID = vintKoujiID;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
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

                    return this.Equals((KeyID)vobjOther);
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(KeyID vobjOther)
                {
                    return this.FabID == vobjOther.FabID && this.KoujiID == vobjOther.KoujiID;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: GetHashCode()のオーバーライド
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// GetHashCode()のオーバーライド
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    int intResult = 1;

                    intResult = intResult * 31 + this.FabID;
                    intResult = intResult * 31 + this.KoujiID;

                    return intResult;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : キーID2（ファブID＋工事ID＋ID）
            // Date    : 2020/ 5/19
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// キーID2（ファブID＋工事ID＋ID）
            /// </summary>
            public struct KeyID2 : IEquatable<KeyID2>
            {
                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 工事ID
                /// </summary>
                public int KoujiID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vintFabID     - in ファブID
                // 　　　　　: vintKoujiID   - in 工事ID
                // 　　　　　: vintID        - in ID
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vintFabID">ファブID</param>
                /// <param name="vintKoujiID">工事ID</param>
                /// <param name="vintID">ID</param>
                public KeyID2(int vintFabID, int vintKoujiID, int vintID)
                {
                    this.FabID = vintFabID;
                    this.KoujiID = vintKoujiID;
                    this.ID = vintID;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
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

                    return this.Equals((KeyID2)vobjOther);
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(KeyID2 vobjOther)
                {
                    return this.FabID == vobjOther.FabID && this.KoujiID == vobjOther.KoujiID && this.ID == vobjOther.ID;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: GetHashCode()のオーバーライド
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// GetHashCode()のオーバーライド
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    int intResult = 1;

                    intResult = intResult * 31 + this.FabID;
                    intResult = intResult * 31 + this.KoujiID;
                    intResult = intResult * 31 + this.ID;

                    return intResult;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : キーID3（工事ID＋ID）
            // Date    : 2020/ 5/19
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// キーID3（工事ID＋ID）
            /// </summary>
            public struct KeyID3 : IEquatable<KeyID3>
            {
                /// <summary>
                /// 工事ID
                /// </summary>
                public int KoujiID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vintKoujiID   - in 工事ID
                // 　　　　　: vintID        - in ID
                //
                // 備考　　　: 2020/ 5/19 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vintKoujiID">工事ID</param>
                /// <param name="vintID">ID</param>
                public KeyID3(int vintKoujiID, int vintID)
                {
                    this.KoujiID = vintKoujiID;
                    this.ID = vintID;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
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

                    return this.Equals((KeyID3)vobjOther);
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性を検証する
                //
                // 引き数　　: vobjOther - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性を検証する
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(KeyID3 vobjOther)
                {
                    return this.KoujiID == vobjOther.KoujiID && this.ID == vobjOther.ID;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: GetHashCode()のオーバーライド
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 4/24 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// GetHashCode()のオーバーライド
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    int intResult = 1;

                    intResult = intResult * 31 + this.KoujiID;
                    intResult = intResult * 31 + this.ID;

                    return intResult;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 座標
            // Date    : 2020/ 4/23
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 座標
            /// </summary>
            public struct Point
            {
                /// <summary>
                /// X座標
                /// </summary>
                public double X;

                /// <summary>
                /// Y座標
                /// </summary>
                public double Y;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vdblX     - in X
                // 　　　　　: vdblY     - in Y
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vdblX">X</param>
                /// <param name="vdblY">Y</param>
                public Point(double vdblX, double vdblY)
                {
                    this.X = vdblX;
                    this.Y = vdblY;
                }

                //-Prop----------------------------------------------------------------
                //
                // 機能　　　: 参照
                //
                // 取得値　　: 原点座標
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 原点座標
                /// </summary>
                public static Point Zero
                {
                    get
                    {
                        return musrZero;
                    }
                }
                private static Point musrZero = new Point(0.0, 0.0);
            }

            //-------------------------------------------------------------------------
            // Title   : 線分
            // Date    : 2020/ 4/23
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 線分
            /// </summary>
            public class Line
            {
                /// <summary>
                /// 始点
                /// </summary>
                public Point Ps;

                /// <summary>
                /// 終点
                /// </summary>
                public Point Pe;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Line()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vusrPs    - in 始点
                // 　　　　　: vusrPe    - in 終点
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vusrPs">始点</param>
                /// <param name="vusrPe">終点</param>
                public Line(Point vusrPs, Point vusrPe)
                {
                    this.Ps = vusrPs;
                    this.Pe = vusrPe;
                }

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
                public Line(Line vobjOther)
                {
                    this.Ps = vobjOther.Ps;
                    this.Pe = vobjOther.Pe;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 円弧
            // Date    : 2020/ 4/23
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 円弧
            /// </summary>
            public class Arc
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
                public Arc()
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
                public Arc(Arc vobjOther)
                {
                    this.Pc = vobjOther.Pc;
                    this.R = vobjOther.R;
                    this.Ps = vobjOther.Ps;
                    this.Pe = vobjOther.Pe;
                    this.Direction = vobjOther.Direction;
                }

                /// <summary>
                /// 中心点
                /// </summary>
                public Point Pc;

                /// <summary>
                /// 半径
                /// </summary>
                public double R;

                /// <summary>
                /// 始点
                /// </summary>
                public Point Ps;

                /// <summary>
                /// 終点
                /// </summary>
                public Point Pe;

                /// <summary>
                /// 向き
                /// </summary>
                public enm.ArcDirection Direction = enm.ArcDirection.Clockwise;

                //---------------------------------------------------------------------
                // Title   : 列挙型 格納クラス
                // Date    : 2020/ 4/23
                // Author  : 金子　淳哉
                // History :
                //---------------------------------------------------------------------
                /// <summary>
                /// 列挙型 格納クラス
                public class enm
                {
                    /// <summary>
                    /// 円弧の向き
                    /// </summary>
                    public enum ArcDirection
                    {
                        /// <summary>
                        /// 時計回り
                        /// </summary>
                        Clockwise = 0,

                        /// <summary>
                        /// 反時計回り
                        /// </summary>
                        Counterclockwise = 1,
                    }
                }
            }

            //-------------------------------------------------------------------------
            // Title   : ３Ｄ座標
            // Date    : 2020/ 4/23
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ３Ｄ座標
            /// </summary>
            public struct Point3D
            {
                /// <summary>
                /// X座標
                /// </summary>
                public double X;

                /// <summary>
                /// Y座標
                /// </summary>
                public double Y;

                /// <summary>
                /// Z座標
                /// </summary>
                public double Z;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vdblX     - in X
                // 　　　　　: vdblY     - in Y
                // 　　　　　: vdblZ     - in Z
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vdblX">X</param>
                /// <param name="vdblY">Y</param>
                /// <param name="vdblZ">Z</param>
                public Point3D(double vdblX, double vdblY, double vdblZ)
                {
                    this.X = vdblX;
                    this.Y = vdblY;
                    this.Z = vdblZ;
                }

                //-Prop----------------------------------------------------------------
                //
                // 機能　　　: 参照
                //
                // 取得値　　: ３Ｄ原点座標
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// ３Ｄ原点座標
                /// </summary>
                public static Point3D Zero
                {
                    get
                    {
                        return musrZero;
                    }
                }
                private static Point3D musrZero = new Point3D(0.0, 0.0, 0.0);
            }

            //-------------------------------------------------------------------------
            // Title   : ３Ｄ線分
            // Date    : 2020/ 4/23
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ３Ｄ線分
            /// </summary>
            public class Line3D
            {
                /// <summary>
                /// 始点
                /// </summary>
                public Point3D Ps;

                /// <summary>
                /// 終点
                /// </summary>
                public Point3D Pe;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Line3D()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vusrPs    - in 始点
                // 　　　　　: vusrPe    - in 終点
                //
                // 備考　　　: 2020/ 4/23 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vusrPs">始点</param>
                /// <param name="vusrPe">終点</param>
                public Line3D(Point3D vusrPs, Point3D vusrPe)
                {
                    this.Ps = vusrPs;
                    this.Pe = vusrPe;
                }

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
                public Line3D(Line3D vobjOther)
                {
                    this.Ps = vobjOther.Ps;
                    this.Pe = vobjOther.Pe;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : ３Ｄ円弧
            // Date    : 2020/ 4/23
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ３Ｄ円弧
            /// </summary>
            public class Arc3D
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
                public Arc3D()
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
                public Arc3D(Arc3D vobjOther)
                {
                    this.Pc = vobjOther.Pc;
                    this.R = vobjOther.R;
                    this.Ps = vobjOther.Ps;
                    this.Pe = vobjOther.Pe;
                    this.Direction = vobjOther.Direction;
                    this.Vector = vobjOther.Vector;
                }

                /// <summary>
                /// 中心点
                /// </summary>
                public Point3D Pc;

                /// <summary>
                /// 半径
                /// </summary>
                public double R;

                /// <summary>
                /// 始点
                /// </summary>
                public Point3D Ps;

                /// <summary>
                /// 終点
                /// </summary>
                public Point3D Pe;

                /// <summary>
                /// 向き
                /// </summary>
                public Arc.enm.ArcDirection Direction = Arc.enm.ArcDirection.Clockwise;

                /// <summary>
                /// 法線ベクトル
                /// </summary>
                public Point3D Vector;
            }

            //-------------------------------------------------------------------------
            // Title   : 色
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 色
            /// </summary>
            public struct Color : IEquatable<Color>
            {
                /// <summary>
                /// Alpha
                /// </summary>
                public byte A;

                /// <summary>
                /// Red
                /// </summary>
                public byte R;

                /// <summary>
                /// Green
                /// </summary>
                public byte G;

                /// <summary>
                /// Blue
                /// </summary>
                public byte B;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vbytR - in Red
                // 　　　　　: vbytG - in Green
                // 　　　　　: vbytB - in Blue
                //
                // 備考　　　: 2020/ 4/30 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vbytR">Red</param>
                /// <param name="vbytG">Green</param>
                /// <param name="vbytB">Blue</param>
                public Color(byte vbytR, byte vbytG, byte vbytB)
                {
                    this.A = 255;
                    this.R = vbytR;
                    this.G = vbytG;
                    this.B = vbytB;
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vbytA - in Alpha
                // 　　　　　: vbytR - in Red
                // 　　　　　: vbytG - in Green
                // 　　　　　: vbytB - in Blue
                //
                // 備考　　　: 2020/ 4/30 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vbytA">Alpha</param>
                /// <param name="vbytR">Red</param>
                /// <param name="vbytG">Green</param>
                /// <param name="vbytB">Blue</param>
                public Color(byte vbytA, byte vbytR, byte vbytG, byte vbytB)
                {
                    this.A = vbytA;
                    this.R = vbytR;
                    this.G = vbytG;
                    this.B = vbytB;
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

                    return this.Equals((Color)vobjOther);
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
                public bool Equals(Color vobjOther)
                {
                    return this.A == vobjOther.A &&
                           this.R == vobjOther.R &&
                           this.G == vobjOther.G &&
                           this.B == vobjOther.B;
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
                    return this.A ^ this.R ^ this.G ^ this.B;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 部材構造
            // Date    : 2020/ 4/20
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 部材構造
            /// </summary>
            public class Material : IEquatable<Material>
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
                public Material()
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
                public Material(Material vobjOther)
                {
                    this.Kind = vobjOther.Kind;
                    this.Shape = vobjOther.Shape;
                    this.WH = vobjOther.WH;
                    this.FH = vobjOther.FH;
                    this.WT = vobjOther.WT;
                    this.FT = vobjOther.FT;
                    this.Size = vobjOther.Size;
                    this.StdF = vobjOther.StdF;
                    this.StdW = vobjOther.StdW;
                    this.R1 = vobjOther.R1;
                    this.R2 = vobjOther.R2;
                    this.R3 = vobjOther.R3;
                    this.UnitMass = vobjOther.UnitMass;
                    this.UnitArea = vobjOther.UnitArea;
                    this.Seam = vobjOther.Seam;
                }

                /// <summary>
                /// 材種ID
                /// </summary>
                public int Kind;

                /// <summary>
                /// 形状
                /// </summary>
                public enm.Shape Shape = enm.Shape.H;

                /// <summary>
                /// ウェブ幅
                /// </summary>
                public double WH;

                /// <summary>
                /// フランジ幅
                /// </summary>
                public double FH;

                /// <summary>
                /// ウェブ厚
                /// </summary>
                public double WT;

                /// <summary>
                /// フランジ厚
                /// </summary>
                public double FT;

                /// <summary>
                /// サイズ文字列
                /// </summary>
                public string Size = "";

                /// <summary>
                /// フランジ材質
                /// </summary>
                public int StdF;

                /// <summary>
                /// ウェブ材質
                /// </summary>
                public int StdW;

                /// <summary>
                /// 曲率半径１
                /// </summary>
                public double R1;

                /// <summary>
                /// 曲率半径２
                /// </summary>
                public double R2;

                /// <summary>
                /// 曲率半径３
                /// </summary>
                public double R3;

                /// <summary>
                /// 単位重量
                /// </summary>
                public double UnitMass;

                /// <summary>
                /// 単位面積
                /// </summary>
                public double UnitArea;

                /// <summary>
                /// シーム(0:なし,1:1箇所,2:2箇所)
                /// </summary>
                public byte Seam;

                //---------------------------------------------------------------------
                //
                // 機能　　　: 同値性の検証
                //
                // 引き数　　: vobjOther     - in 比較対象
                // 　　　　　: 
                //
                // 返り値　　: 真＝等しい、偽＝等しくない
                //
                // 備考　　　: 2020/ 5/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性の検証
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

                    return this.Equals((Material)vobjOther);
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
                // 備考　　　: 2020/ 5/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// 同値性の検証
                /// </summary>
                /// <param name="vobjOther">比較対象</param>
                /// <returns>真＝等しい、偽＝等しくない</returns>
                public bool Equals(Material vobjOther)
                {
                    if (this.Kind == vobjOther.Kind &&
                        this.Shape == vobjOther.Shape &&
                        this.WH == vobjOther.WH &&
                        this.FH == vobjOther.FH &&
                        this.WT == vobjOther.WT &&
                        this.FT == vobjOther.FT &&
                        this.Size == vobjOther.Size &&
                        this.StdF == vobjOther.StdF &&
                        this.StdW == vobjOther.StdW &&
                        this.R1 == vobjOther.R1 &&
                        this.R2 == vobjOther.R2 &&
                        this.R3 == vobjOther.R3 &&
                        this.UnitMass == vobjOther.UnitMass &&
                        this.UnitArea == vobjOther.UnitArea &&
                        this.Seam == vobjOther.Seam)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: このオブジェクトのハッシュ値を取得する
                //
                // 引き数　　: 
                // 　　　　　: 
                //
                // 返り値　　: ハッシュ値
                //
                // 備考　　　: 2020/ 5/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// このオブジェクトのハッシュ値を取得する
                /// </summary>
                /// <returns>ハッシュ値</returns>
                public override int GetHashCode()
                {
                    return this.Kind ^
                           this.Shape.GetHashCode() ^
                           this.WH.GetHashCode() ^
                           this.FH.GetHashCode() ^
                           this.WT.GetHashCode() ^
                           this.FT.GetHashCode() ^
                           this.Size.GetHashCode() ^
                           this.StdF ^
                           this.StdW ^
                           this.R1.GetHashCode() ^
                           this.R2.GetHashCode() ^
                           this.R3.GetHashCode() ^
                           this.UnitMass.GetHashCode() ^
                           this.UnitArea.GetHashCode() ^
                           this.Seam;
                }
            }
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 文字列を列挙体変数に変換する
        //
        // 引き数　　: vstrData      - in 文字列
        // 　　　　　: 
        //
        // 返り値　　: 列挙体変数
        //
        // 備考　　　: 2020/ 5/26 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 文字列を列挙体変数に変換する
        /// ※対応する列挙体変数が見付からなかった場合はデフォルト値を返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vstrData">文字列</param>
        /// <returns>列挙体変数</returns>
        public static T Conv_StringToEnum<T>(string vstrData)
            where T : Enum
        {
            foreach (T enmT in Enum.GetValues(typeof(T)))
            {
                if (enmT.ToString() == vstrData)
                {
                    return enmT;
                }
            }

            return default(T);
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 引数にとったコントロールの描画を抑止する
        //             任意の処理の後、EndControlUpdate()を呼び出し抑止を解除してください
        //             BeginUpdate()関数を実装しているコントロールの場合はそちらを使用してください
        //
        // 引き数　　: control - in コントロール
        // 　　　　　: 
        //
        // 備考　　　: 2015/ 8/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 引数にとったコントロールの描画を抑止する
        /// 任意の処理の後、EndControlUpdate()を呼び出し抑止を解除してください
        /// BeginUpdate()関数を実装しているコントロールの場合はそちらを使用してください
        /// </summary>
        /// <param name="control">コントロール</param>
        public static void BeginControlUpdate(Control control)
        {
            SendMessage(new HandleRef(control, control.Handle), WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: 引数にとったコントロールの描画抑止を解除する
        //
        // 引き数　　: control - in コントロール
        // 　　　　　: 
        //
        // 備考　　　: 2015/ 8/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// 引数にとったコントロールの描画抑止を解除する
        /// </summary>
        /// <param name="control">コントロール</param>
        public static void EndControlUpdate(Control control)
        {
            SendMessage(new HandleRef(control, control.Handle), WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
            control.Invalidate();
        }

        //---------------------------------------------------------------------
        //
        // 機能　　　: Windos APIの呼び出し
        //             Windowsメッセージを発行する
        //
        // 引き数　　: hWnd - in コントロールのウィンドウハンドル
        // 　　　　　: msg - in メッセージ
        // 　　　　　: wParam - in パラメータ１
        // 　　　　　: lParam - in パラメータ２
        //
        // 返り値　　: メッセージ処理の結果
        //
        // 備考　　　: 2015/ 8/18 - 金子　淳哉
        //
        //---------------------------------------------------------------------
        /// <summary>
        /// Windos APIの呼び出し
        /// Windowsメッセージを発行する
        /// </summary>
        /// <param name="hWnd">コントロールのウィンドウハンドル</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="wParam">パラメータ１</param>
        /// <param name="lParam">パラメータ２</param>
        /// <returns>メッセージ処理の結果</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Windowsメッセージ（0x000B）：ウインドウ内の再描画を許可または禁止します。
        /// </summary>
        private const int WM_SETREDRAW = 0x000B;
    }
}
