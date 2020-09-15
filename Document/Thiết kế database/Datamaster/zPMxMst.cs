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
    // Title   : 生産管理マスターデータ構造
    // Date    : 2020/ 4/17
    // Author  : 金子　淳哉
    // History :
    //-------------------------------------------------------------------------
    /// <summary>
    /// 生産管理マスターデータ構造
    /// </summary>
    public class zPMxMst
    {
        //---------------------------------------------------------------------
        // Title   : 列挙型 格納クラス
        // Date    : 2020/ 4/16
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 列挙型 格納クラス
        /// </summary>
        public class enm
        {
            //-----------------------------------------------------------------
            // Title   : 属性
            // History : 2020/ 4/16 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 属性
            /// </summary>
            public enum Attrib
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 部材
                /// </summary>
                Buzai = 1,

                /// <summary>
                /// タイコ
                /// </summary>
                Taiko = 2,

                /// <summary>
                /// 仕口
                /// </summary>
                Shiguchi = 3,

                /// <summary>
                /// 製品
                /// </summary>
                Seihin = 4,

                /// <summary>
                /// 型板
                /// </summary>
                Kataita = 5,

                /// <summary>
                /// 部品
                /// </summary>
                Buhin = 6,
            }

            //-----------------------------------------------------------------
            // Title   : 生産能力
            // History : 2020/ 4/16 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 生産能力
            /// </summary>
            public enum Ability
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 台数
                /// </summary>
                Count = 1,

                /// <summary>
                /// 溶接長
                /// </summary>
                WeldLen = 2,

                /// <summary>
                /// 溶接箇所数
                /// </summary>
                WeldCount = 3,

                /// <summary>
                /// 重量
                /// </summary>
                Weight = 4,

                /// <summary>
                /// 表面積
                /// </summary>
                SurfaceArea = 5,

                /// <summary>
                /// 穴数
                /// </summary>
                HoleCount = 6,

                /// <summary>
                /// 長さ
                /// </summary>
                Length = 7,

                /// <summary>
                /// 全品
                /// </summary>
                All = 99,
            }

            //-----------------------------------------------------------------
            // Title   : 開先
            // History : 2020/ 4/17 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 開先
            /// </summary>
            public enum WeldTip
            {
                /// <summary>
                /// なし
                /// </summary>
                None = 0,

                /// <summary>
                /// 外開先
                /// </summary>
                Outside = 1,

                /// <summary>
                /// 内開先
                /// </summary>
                Inside = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 工事の状態を表す列挙体
            // History : 2020/ 4/28 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 工事の状態を表す列挙体
            /// </summary>
            public enum KoujiStatus
            {
                /// <summary>
                /// 見積り段階
                /// </summary>
                Estimate = 0,

                /// <summary>
                /// 施工中
                /// </summary>
                Running = 1,

                /// <summary>
                /// 完成
                /// </summary>
                Finished = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 塗装区分
            // History : 2020/ 4/30 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 塗装区分
            /// </summary>
            public enum PaintKind
            {
                /// <summary>
                /// 塗装
                /// </summary>
                Paint = 0,

                /// <summary>
                /// メッキ
                /// </summary>
                Plating = 1,
            }

            //-----------------------------------------------------------------
            // Title   : メッキタイプ
            // History : 2020/ 5/ 8 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// メッキタイプ
            /// </summary>
            public enum PlatingType
            {
                /// <summary>
                /// メッキなし
                /// </summary>
                None = 0,

                /// <summary>
                /// 通常メッキ
                /// </summary>
                Normal = 1,

                /// <summary>
                /// 先行メッキ
                /// </summary>
                Priority = 2,
            }

            //-----------------------------------------------------------------
            // Title   : 製作先
            // History : 2020/ 5/11 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 製作先
            /// </summary>
            public enum WorkPlace
            {
                /// <summary>
                /// 内製
                /// </summary>
                Self = 0,

                /// <summary>
                /// 外注
                /// </summary>
                Outsourcing = 1,
            }

            //-----------------------------------------------------------------
            // Title   : 比較タイプ
            // History : 2020/ 5/11 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 比較タイプ
            /// </summary>
            public enum CompType
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 一致
                /// </summary>
                Match = 1,

                /// <summary>
                /// 異なる
                /// </summary>
                NotMatch = 2,
            }

            //-----------------------------------------------------------------
            // Title   : ボルト属性
            // History : 2020/ 5/22 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// ボルト属性
            /// </summary>
            public enum BoltAttribute
            {
                /// <summary>
                /// 未定義
                /// </summary>
                [attEnumLabel("")]
                Undefined = 0,

                /// <summary>
                /// 現場ボルト
                /// </summary>
                [attEnumLabel("現場ボルト")]
                Genba = 1,

                /// <summary>
                /// 中ボルト
                /// </summary>
                [attEnumLabel("中ボルト")]
                Naka = 2,
            }
        }//End Class

        //---------------------------------------------------------------------
        // Title   : 構造体 格納クラス
        // Date    : 2020/ 4/16
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 構造体 格納クラス
        /// </summary>
        public class typ
        {
            //-------------------------------------------------------------------------
            // Title   : 共通マスター
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 共通マスター
            /// </summary>
            public class PMMstCom
            {
                /// <summary>
                /// 形状
                /// </summary>
                public List<Shape> Shape = new List<Shape>();

                /// <summary>
                /// 材質
                /// </summary>
                public List<Std> Std = new List<Std>();

                /// <summary>
                /// 材種
                /// </summary>
                public List<Kind> Kind = new List<Kind>();
            }

            //-------------------------------------------------------------------------
            // Title   : ユーザー別マスター
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ユーザー別マスター
            /// </summary>
            public class PMMstUser
            {
                /// <summary>
                /// 材質個別
                /// </summary>
                public List<StdUser> StdUser = new List<StdUser>();

                /// <summary>
                /// 材種個別
                /// </summary>
                public List<KindUser> KindUser = new List<KindUser>();
            }

            //-------------------------------------------------------------------------
            // Title   : 工事別マスター
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 工事別マスター
            /// </summary>
            public class PMMstKouji
            {
                /// <summary>
                /// 材種工事別
                /// </summary>
                public List<KindKouji> KindKouji = new List<KindKouji>();

                /// <summary>
                /// 塗装
                /// </summary>
                public List<Paint> Paint = new List<Paint>();

                /// <summary>
                /// ボルト
                /// </summary>
                public List<Bolt> Bolt = new List<Bolt>();
            }

            //-------------------------------------------------------------------------
            // Title   : マスターデータ格納クラス
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// マスターデータ格納クラス
            /// </summary>
            public class PMMst
            {
                /// <summary>
                /// ファブ
                /// </summary>
                public List<Fab> Fab = new List<Fab>();

                /// <summary>
                /// 例外日
                /// </summary>
                public List<ExDay> ExDay = new List<ExDay>();

                /// <summary>
                /// 工事
                /// </summary>
                public List<Kouji> Kouji = new List<Kouji>();

                /// <summary>
                /// 工場
                /// </summary>
                public List<Factory> Factory = new List<Factory>();

                /// <summary>
                /// ヤード
                /// </summary>
                public List<Yard> Yard = new List<Yard>();

                /// <summary>
                /// 作業者
                /// </summary>
                public List<Employee> Employee = new List<Employee>();

                /// <summary>
                /// 班
                /// </summary>
                public List<Department> Department = new List<Department>();

                /// <summary>
                /// 所属
                /// </summary>
                public List<Affiliation> Affiliation = new List<Affiliation>();

                /// <summary>
                /// 作業
                /// </summary>
                public List<WorkContent> WorkContent = new List<WorkContent>();

                /// <summary>
                /// セクション
                /// </summary>
                public List<WorkSection> WorkSection = new List<WorkSection>();

                /// <summary>
                /// 製作工程
                /// </summary>
                public List<WorkProcess> WorkProcess = new List<WorkProcess>();

                /// <summary>
                /// 構成セクション
                /// </summary>
                public List<CompSec> CompSec = new List<CompSec>();

                /// <summary>
                /// 外注先
                /// </summary>
                public List<Outsourcing> Outsourcing = new List<Outsourcing>();
            }

            //-------------------------------------------------------------------------
            // Title   : 形状
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 形状
            /// </summary>
            public class Shape
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// サイズ数
                /// </summary>
                public short SizeCt;

                /// <summary>
                /// 半径数
                /// </summary>
                public short RadCt;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: 
                //
                // 備考　　　: 2020/ 6/11 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                public Shape()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 6/11 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Shape(Shape vobjOther)
                {
                    this.ID = vobjOther.ID;
                    this.Name = vobjOther.Name;
                    this.SizeCt = vobjOther.SizeCt;
                    this.RadCt = vobjOther.RadCt;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : 材質
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 材質
            /// </summary>
            public class Std
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";
            }

            //-------------------------------------------------------------------------
            // Title   : 材種
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 材種
            /// </summary>
            public class Kind
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 形状ID
                /// </summary>
                public int ShapeID;

                /// <summary>
                /// 材料検索
                /// </summary>
                public short SearchNumber;
            }

            //-------------------------------------------------------------------------
            // Title   : 材質個別
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 材質個別
            /// </summary>
            public class StdUser
            {
                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 材質ID
                /// </summary>
                public int StdID;

                /// <summary>
                /// 材質コード
                /// </summary>
                public int Code;
            }

            //-------------------------------------------------------------------------
            // Title   : 材種個別
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 材種個別
            /// </summary>
            public class KindUser
            {
                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 材種ID
                /// </summary>
                public int KindID;

                /// <summary>
                /// 材質コード
                /// </summary>
                public int Code;

                /// <summary>
                /// 並び順
                /// </summary>
                public int Seq;
            }

            //-------------------------------------------------------------------------
            // Title   : 材種工事別
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 材種工事別
            /// </summary>
            public class KindKouji
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
                /// 材種ID
                /// </summary>
                public int KindID;

                /// <summary>
                /// 材種略称
                /// </summary>
                public string KindAbbr = "";

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
                public KindKouji()
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
                public KindKouji(KindKouji vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.KoujiID = vobjOther.KoujiID;
                    this.KindID = vobjOther.KindID;
                    this.KindAbbr = vobjOther.KindAbbr;
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
            public class Paint
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

                /// <summary>
                /// コード
                /// </summary>
                public int Code;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 区分
                /// </summary>
                public enm.PaintKind Kind = enm.PaintKind.Paint;

                /// <summary>
                /// 先行メッキフラグ
                /// </summary>
                /// <remarks>
                /// 区分＝メッキの場合に有効
                /// </remarks>
                public bool PriorityPlating = false;

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
                public Paint()
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
                public Paint(Paint vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.KoujiID = vobjOther.KoujiID;
                    this.ID = vobjOther.ID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.Kind = vobjOther.Kind;
                    this.PriorityPlating = vobjOther.PriorityPlating;
                }
            }

            //-------------------------------------------------------------------------
            // Title   : ボルト
            // Date    : 2020/ 5/22
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ボルト
            /// </summary>
            public class Bolt
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
                public Bolt()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/22 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Bolt(Bolt vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.KoujiID = vobjOther.KoujiID;
                    this.ID = vobjOther.ID;
                    this.Name = vobjOther.Name;
                    this.Code = vobjOther.Code;
                    this.Kind = vobjOther.Kind;
                    this.Std = vobjOther.Std;
                    this.Attribute = vobjOther.Attribute;
                }

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

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// コード
                /// </summary>
                public int Code;

                /// <summary>
                /// 材種
                /// </summary>
                public int Kind;

                /// <summary>
                /// 材質
                /// </summary>
                public int Std;

                /// <summary>
                /// ボルト属性
                /// </summary>
                public enm.BoltAttribute Attribute = enm.BoltAttribute.Undefined;
            }

            //-------------------------------------------------------------------------
            // Title   : ファブ
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ファブ
            /// </summary>
            public class Fab
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";
            }

            //-------------------------------------------------------------------------
            // Title   : 例外日
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 例外日
            /// </summary>
            public class ExDay
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
                public ExDay()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                // 　　　　　: 
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public ExDay(ExDay vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.FactoryID = vobjOther.FactoryID;
                    this.Year = vobjOther.Year;
                    this.Month = vobjOther.Month;
                    this.Day = vobjOther.Day;
                    this.Work = vobjOther.Work;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 工場ID
                /// </summary>
                public int FactoryID;

                /// <summary>
                /// 年
                /// </summary>
                public int Year;

                /// <summary>
                /// 月
                /// </summary>
                public int Month;

                /// <summary>
                /// 日
                /// </summary>
                public int Day;

                /// <summary>
                /// 稼働
                /// </summary>
                public bool Work = true;

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolExDay         - in 例外日データ
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolExDay">例外日データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.ExDay> vcolExDay)
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
                            objWriter.WriteStartElement("ExDayData");
                            {
                                foreach (zPMxMst.typ.ExDay objExDay in vcolExDay)
                                {
                                    objWriter.WriteStartElement("ExDay");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objExDay.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("FactoryID");
                                        {
                                            objWriter.WriteString(objExDay.FactoryID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Year");
                                        {
                                            objWriter.WriteString(objExDay.Year.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Month");
                                        {
                                            objWriter.WriteString(objExDay.Month.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Day");
                                        {
                                            objWriter.WriteString(objExDay.Day.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Work");
                                        {
                                            objWriter.WriteString(objExDay.Work.ToString().ToLower());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolExData        - out 例外日データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolExData">例外日データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.ExDay> rcolExData)
                {
                    rcolExData = new List<ExDay>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.ExDay objExDay = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "ExDay":
                                        {
                                            objExDay = new ExDay();
                                            rcolExData.Add(objExDay);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objExDay.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "FactoryID":
                                        {
                                            objExDay.FactoryID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Year":
                                        {
                                            objExDay.Year = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Month":
                                        {
                                            objExDay.Month = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Day":
                                        {
                                            objExDay.Day = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Work":
                                        {
                                            objExDay.Work = objReader.ReadElementContentAsBoolean();
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
            // Title   : 工事
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 工事
            /// </summary>
            public class Kouji
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
                public Kouji()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Kouji(Kouji vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.Name = vobjOther.Name;
                    this.HeaderMark = vobjOther.HeaderMark;
                    this.Status = vobjOther.Status;
                    this.Color = vobjOther.Color;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 工事名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 頭番
                /// </summary>
                public string HeaderMark = "";

                /// <summary>
                /// ステータス
                /// </summary>
                public enm.KoujiStatus Status = enm.KoujiStatus.Estimate;

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color = new zPMxCom.typ.Color(255, 255, 255);

                /// <summary>
                /// 開始日
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddHHmmss
                /// </remarks>
                public string StartDate = "";

                /// <summary>
                /// 終了日
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddHHmmss
                /// </remarks>
                public string EndDate = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolKouji         - in 工事データ
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolKouji">工事データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.Kouji> vcolKouji)
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
                            objWriter.WriteStartElement("KoujiData");
                            {
                                foreach (zPMxMst.typ.Kouji objKouji in vcolKouji)
                                {
                                    objWriter.WriteStartElement("Kouji");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objKouji.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objKouji.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objKouji.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("HeaderMark");
                                        {
                                            objWriter.WriteString(objKouji.HeaderMark.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Status");
                                        {
                                            objWriter.WriteString(objKouji.Status.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Color");
                                        {
                                            objWriter.WriteStartElement("A");
                                            {
                                                objWriter.WriteString(objKouji.Color.A.ToString());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("R");
                                            {
                                                objWriter.WriteString(objKouji.Color.R.ToString());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("G");
                                            {
                                                objWriter.WriteString(objKouji.Color.G.ToString());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("B");
                                            {
                                                objWriter.WriteString(objKouji.Color.B.ToString());
                                            }
                                            objWriter.WriteEndElement();
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("StartDate");
                                        {
                                            objWriter.WriteString(objKouji.StartDate);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("EndDate");
                                        {
                                            objWriter.WriteString(objKouji.EndDate);
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolKouji         - out 工事データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolKouji">工事データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.Kouji> rcolKouji)
                {
                    rcolKouji = new List<Kouji>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.Kouji objKouji = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Kouji":
                                        {
                                            objKouji = new Kouji();
                                            rcolKouji.Add(objKouji);
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objKouji.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objKouji.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objKouji.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "HeaderMark":
                                        {
                                            objKouji.HeaderMark = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Status":
                                        {
                                            objKouji.Status = zPMxCom.Conv_StringToEnum<zPMxMst.enm.KoujiStatus>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "A":
                                        {
                                            objKouji.Color.A = (byte)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "R":
                                        {
                                            objKouji.Color.R = (byte)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "G":
                                        {
                                            objKouji.Color.G = (byte)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "B":
                                        {
                                            objKouji.Color.B = (byte)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "StartDate":
                                        {
                                            objKouji.StartDate = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "EndDate":
                                        {
                                            objKouji.EndDate = objReader.ReadElementContentAsString();
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
            // Title   : 工場
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 工場
            /// </summary>
            public class Factory
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
                public Factory()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Factory(Factory vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.Flag = vobjOther.Flag;
                    this.Name = vobjOther.Name;
                    this.WorkSaturday = vobjOther.WorkSaturday;
                    this.WorkSunday = vobjOther.WorkSunday;
                    this.WorkHoliday = vobjOther.WorkHoliday;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 工場名
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 土曜稼働
                /// </summary>
                public bool WorkSaturday = false;

                /// <summary>
                /// 日曜稼働
                /// </summary>
                public bool WorkSunday = false;

                /// <summary>
                /// 祝日稼働
                /// </summary>
                public bool WorkHoliday = false;

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolFactory       - in 工場データ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// ※カレンダーの例外日データは保存されません。
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolFactory">工場データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.Factory> vcolFactory)
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
                            objWriter.WriteStartElement("FactoryData");
                            {
                                foreach (zPMxMst.typ.Factory objFactory in vcolFactory)
                                {
                                    objWriter.WriteStartElement("Factory");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objFactory.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objFactory.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objFactory.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objFactory.Name);
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Calendar");
                                        {
                                            objWriter.WriteStartElement("WorkSaturday");
                                            {
                                                objWriter.WriteString(objFactory.WorkSaturday.ToString().ToLower());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("WorkSunday");
                                            {
                                                objWriter.WriteString(objFactory.WorkSunday.ToString().ToLower());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("WorkHoliday");
                                            {
                                                objWriter.WriteString(objFactory.WorkHoliday.ToString().ToLower());
                                            }
                                            objWriter.WriteEndElement();
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolFactory       - out 工場データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// ※カレンダーの例外日データは読み込まれません。
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolFactory">工場データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.Factory> rcolFactory)
                {
                    rcolFactory = new List<Factory>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.Factory objFactory = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Factory":
                                        {
                                            objFactory = new Factory();
                                            rcolFactory.Add(objFactory);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objFactory.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objFactory.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objFactory.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objFactory.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "WorkSaturday":
                                        {
                                            objFactory.WorkSaturday = objReader.ReadElementContentAsBoolean();
                                        }
                                        break;

                                    case "WorkSunday":
                                        {
                                            objFactory.WorkSunday = objReader.ReadElementContentAsBoolean();
                                        }
                                        break;

                                    case "WorkHoliday":
                                        {
                                            objFactory.WorkHoliday = objReader.ReadElementContentAsBoolean();
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
            // Title   : ヤード
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// ヤード
            /// </summary>
            public class Yard
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
                public Yard()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Yard(Yard vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.FactoryID = vobjOther.FactoryID;
                    this.Flag = vobjOther.Flag;
                    this.ID = vobjOther.ID;
                    this.Name = vobjOther.Name;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 工場ID
                /// </summary>
                public int FactoryID;

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

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolYard          - in ヤードデータ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolYard">ヤードデータ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.Yard> vcolYard)
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
                            objWriter.WriteStartElement("YardData");
                            {
                                foreach (zPMxMst.typ.Yard objYard in vcolYard)
                                {
                                    objWriter.WriteStartElement("Yard");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objYard.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("FactoryID");
                                        {
                                            objWriter.WriteString(objYard.FactoryID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objYard.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objYard.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objYard.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolYard          - out ヤードデータ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolYard">ヤードデータ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.Yard> rcolYard)
                {
                    rcolYard = new List<Yard>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.Yard objYard = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Yard":
                                        {
                                            objYard = new Yard();
                                            rcolYard.Add(objYard);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objYard.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "FactoryID":
                                        {
                                            objYard.FactoryID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objYard.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objYard.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objYard.Name = objReader.ReadElementContentAsString();
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
            // Title   : 作業者
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 作業者
            /// </summary>
            public class Employee
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
                public Employee()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - i/o コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Employee(Employee vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.Flag = vobjOther.Flag;
                    this.Name = vobjOther.Name;
                    this.WorkContentID = vobjOther.WorkContentID;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 氏名
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 作業ID
                /// </summary>
                public int WorkContentID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolEmployee      - in 作業者データ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolEmployee">作業者データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.Employee> vcolEmployee)
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
                            objWriter.WriteStartElement("EmployeeData");
                            {
                                foreach (zPMxMst.typ.Employee objEmployee in vcolEmployee)
                                {
                                    objWriter.WriteStartElement("Employee");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objEmployee.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objEmployee.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objEmployee.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objEmployee.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WorkContentID");
                                        {
                                            objWriter.WriteString(objEmployee.WorkContentID.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolEmployee      - out 作業者データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolEmployee">作業者データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.Employee> rcolEmployee)
                {
                    rcolEmployee = new List<Employee>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.Employee objEmployee = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Employee":
                                        {
                                            objEmployee = new Employee();
                                            rcolEmployee.Add(objEmployee);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objEmployee.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objEmployee.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objEmployee.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objEmployee.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "WorkContentID":
                                        {
                                            objEmployee.WorkContentID = objReader.ReadElementContentAsInt();
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
            // Title   : 班
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 班
            /// </summary>
            public class Department
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
                public Department()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Department(Department vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.Flag = vobjOther.Flag;
                    this.Name = vobjOther.Name;
                    this.Color = vobjOther.Color;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color = new zPMxCom.typ.Color(255, 255, 255);

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolEmployee      - in 班データ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolDepartment">班データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.Department> vcolDepartment)
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
                            objWriter.WriteStartElement("DepartmentData");
                            {
                                foreach (zPMxMst.typ.Department objDepartment in vcolDepartment)
                                {
                                    objWriter.WriteStartElement("Department");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objDepartment.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objDepartment.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objDepartment.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objDepartment.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Color");
                                        {
                                            objWriter.WriteStartElement("A");
                                            {
                                                objWriter.WriteString(objDepartment.Color.A.ToString());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("R");
                                            {
                                                objWriter.WriteString(objDepartment.Color.R.ToString());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("G");
                                            {
                                                objWriter.WriteString(objDepartment.Color.G.ToString());
                                            }
                                            objWriter.WriteEndElement();

                                            objWriter.WriteStartElement("B");
                                            {
                                                objWriter.WriteString(objDepartment.Color.B.ToString());
                                            }
                                            objWriter.WriteEndElement();
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolDepartment    - out 班データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolDepartment">班データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.Department> rcolDepartment)
                {
                    rcolDepartment = new List<Department>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.Department objDepartment = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Department":
                                        {
                                            objDepartment = new Department();
                                            rcolDepartment.Add(objDepartment);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objDepartment.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objDepartment.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objDepartment.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objDepartment.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "A":
                                        {
                                            objDepartment.Color.A = (byte)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "R":
                                        {
                                            objDepartment.Color.R = (byte)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "G":
                                        {
                                            objDepartment.Color.G = (byte)objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "B":
                                        {
                                            objDepartment.Color.B = (byte)objReader.ReadElementContentAsInt();
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
            // Title   : 所属
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 所属
            /// </summary>
            public class Affiliation
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
                public Affiliation()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Affiliation(Affiliation vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.Flag = vobjOther.Flag;
                    this.DepartmentID = vobjOther.DepartmentID;
                    this.EmployeeID.AddRange(vobjOther.EmployeeID);
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
                /// 班ID
                /// </summary>
                public int DepartmentID;

                /// <summary>
                /// 作業者ID
                /// </summary>
                public List<int> EmployeeID = new List<int>();

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolAffiliation   - in 所属データ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolAffiliation">所属データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.Affiliation> vcolAffiliation)
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
                            objWriter.WriteStartElement("AffiliationData");
                            {
                                foreach (zPMxMst.typ.Affiliation objAffiliation in vcolAffiliation)
                                {
                                    objWriter.WriteStartElement("Affiliation");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objAffiliation.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objAffiliation.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DepartmentID");
                                        {
                                            objWriter.WriteString(objAffiliation.DepartmentID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("EmployeeIDData");
                                        {
                                            foreach (int intEmployeeID in objAffiliation.EmployeeID)
                                            {
                                                objWriter.WriteStartElement("EmployeeID");
                                                {
                                                    objWriter.WriteString(intEmployeeID.ToString());
                                                }
                                                objWriter.WriteEndElement();
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

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolAffiliation   - out 所属データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolAffiliation">所属データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.Affiliation> rcolAffiliation)
                {
                    rcolAffiliation = new List<Affiliation>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.Affiliation objAffiliation = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Affiliation":
                                        {
                                            objAffiliation = new Affiliation();
                                            rcolAffiliation.Add(objAffiliation);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objAffiliation.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objAffiliation.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "DepartmentID":
                                        {
                                            objAffiliation.DepartmentID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "EmployeeID":
                                        {
                                            objAffiliation.EmployeeID.Add(objReader.ReadElementContentAsInt());
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
            // Title   : 作業
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 作業
            /// </summary>
            public class WorkContent
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
                public WorkContent()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WorkContent(WorkContent vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.Flag = vobjOther.Flag;
                    this.Level = vobjOther.Level;
                    this.ParentID = vobjOther.ParentID;
                    this.Code = vobjOther.Code;
                    this.Name = vobjOther.Name;
                    this.SortOrder = vobjOther.SortOrder;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// レベル
                /// </summary>
                public int Level;

                /// <summary>
                /// 親作業ID
                /// </summary>
                public int ParentID;

                /// <summary>
                /// 作業コード
                /// </summary>
                public int Code;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 並び順
                /// </summary>
                public int SortOrder;

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolWorkContent   - in 作業データ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolWorkContent">作業データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.WorkContent> vcolWorkContent)
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
                            objWriter.WriteStartElement("WorkContentData");
                            {
                                foreach (zPMxMst.typ.WorkContent objWorkContent in vcolWorkContent)
                                {
                                    objWriter.WriteStartElement("WorkContent");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objWorkContent.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objWorkContent.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objWorkContent.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Level");
                                        {
                                            objWriter.WriteString(objWorkContent.Level.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ParentID");
                                        {
                                            objWriter.WriteString(objWorkContent.ParentID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Code");
                                        {
                                            objWriter.WriteString(objWorkContent.Code.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objWorkContent.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("SortOrder");
                                        {
                                            objWriter.WriteString(objWorkContent.SortOrder.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolWorkContent   - out 作業データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolWorkContent">作業データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.WorkContent> rcolWorkContent)
                {
                    rcolWorkContent = new List<WorkContent>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.WorkContent objWorkContent = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "WorkContent":
                                        {
                                            objWorkContent = new WorkContent();
                                            rcolWorkContent.Add(objWorkContent);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objWorkContent.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objWorkContent.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objWorkContent.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Level":
                                        {
                                            objWorkContent.Level = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ParentID":
                                        {
                                            objWorkContent.ParentID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Code":
                                        {
                                            objWorkContent.Code = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objWorkContent.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "SortOrder":
                                        {
                                            objWorkContent.SortOrder = objReader.ReadElementContentAsInt();
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
            // Title   : セクション
            // Date    : 2020/ 4/16
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// セクション
            /// </summary>
            public class WorkSection
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
                public WorkSection()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WorkSection(WorkSection vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.FactoryID = vobjOther.FactoryID;
                    this.Flag = vobjOther.Flag;
                    this.Name = vobjOther.Name;
                    this.Place = vobjOther.Place;
                    this.OutsourcingReturn = vobjOther.OutsourcingReturn;
                    this.OutsourcingTerm = vobjOther.OutsourcingTerm;
                    this.Ability = vobjOther.Ability;
                    this.Amount = vobjOther.Amount;
                    this.Attrib = vobjOther.Attrib;
                    this.CompType_Haunch = vobjOther.CompType_Haunch;
                    this.Haunch = vobjOther.Haunch;
                    this.CompType_PlatingType = vobjOther.CompType_PlatingType;
                    this.PlatingType = vobjOther.PlatingType;
                    this.CompType_WeldScallopKind = vobjOther.CompType_WeldScallopKind;
                    this.WeldScallopKind = vobjOther.WeldScallopKind;
                    this.CompType_WeldTip = vobjOther.CompType_WeldTip;
                    this.WeldTip = vobjOther.WeldTip;
                    this.CompType_Std = vobjOther.CompType_Std;
                    this.StdID.AddRange(vobjOther.StdID);
                    this.CompType_Shape = vobjOther.CompType_Shape;
                    this.ShapeID.AddRange(vobjOther.ShapeID);
                    this.CompType_Kind = vobjOther.CompType_Kind;
                    this.KindID.AddRange(vobjOther.KindID);
                    this.CompType_BuzaiKind = vobjOther.CompType_BuzaiKind;
                    this.BuzaiKind.AddRange(vobjOther.BuzaiKind);
                    this.CompType_Size1 = vobjOther.CompType_Size1;
                    this.Size1Min = vobjOther.Size1Min;
                    this.Size1Max = vobjOther.Size1Max;
                    this.CompType_Size2 = vobjOther.CompType_Size2;
                    this.Size2Min = vobjOther.Size2Min;
                    this.Size2Max = vobjOther.Size2Max;
                    this.CompType_Size3 = vobjOther.CompType_Size3;
                    this.Size3Min = vobjOther.Size3Min;
                    this.Size3Max = vobjOther.Size3Max;
                    this.CompType_Size4 = vobjOther.CompType_Size4;
                    this.Size4Min = vobjOther.Size4Min;
                    this.Size4Max = vobjOther.Size4Max;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 工場ID
                /// </summary>
                public int FactoryID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                /// <summary>
                /// 製作先
                /// </summary>
                public enm.WorkPlace Place = enm.WorkPlace.Self;

                /// <summary>
                /// 外注戻り有り
                /// </summary>
                public bool OutsourcingReturn = false;

                /// <summary>
                /// 外注製作期間
                /// </summary>
                /// <remarks>
                /// 日数を指定
                /// </remarks>
                public int OutsourcingTerm = 1;

                /// <summary>
                /// 生産能力
                /// </summary>
                public enm.Ability Ability = enm.Ability.Undefined;

                /// <summary>
                /// 生産量
                /// </summary>
                public double Amount;

                /// <summary>
                /// 属性
                /// </summary>
                public enm.Attrib Attrib = enm.Attrib.Undefined;

                /// <summary>
                /// ハンチ有無指定
                /// </summary>
                public enm.CompType CompType_Haunch = enm.CompType.Undefined;

                /// <summary>
                /// ハンチ有無
                /// </summary>
                public bool Haunch = false;

                /// <summary>
                /// メッキタイプ指定
                /// </summary>
                public enm.CompType CompType_PlatingType = enm.CompType.Undefined;

                /// <summary>
                /// メッキタイプ
                /// </summary>
                public enm.PlatingType PlatingType = enm.PlatingType.None;

                /// <summary>
                /// スカラップ指定
                /// </summary>
                public enm.CompType CompType_WeldScallopKind = enm.CompType.Undefined;

                /// <summary>
                /// スカラップ
                /// </summary>
                public zPMxCom.enm.WeldScallopKind WeldScallopKind = zPMxCom.enm.WeldScallopKind.None;

                /// <summary>
                /// 開先指定
                /// </summary>
                public enm.CompType CompType_WeldTip = enm.CompType.Undefined;

                /// <summary>
                /// 開先
                /// </summary>
                public enm.WeldTip WeldTip = enm.WeldTip.None;

                /// <summary>
                /// 材質指定
                /// </summary>
                public enm.CompType CompType_Std = enm.CompType.Undefined;

                /// <summary>
                /// 材質ID
                /// </summary>
                public List<int> StdID = new List<int>();

                /// <summary>
                /// 形状指定
                /// </summary>
                public enm.CompType CompType_Shape = enm.CompType.Undefined;

                /// <summary>
                /// 形状ID
                /// </summary>
                public List<int> ShapeID = new List<int>();

                /// <summary>
                /// 材種指定
                /// </summary>
                public enm.CompType CompType_Kind = enm.CompType.Undefined;

                /// <summary>
                /// 材種ID
                /// </summary>
                public List<int> KindID = new List<int>();

                /// <summary>
                /// 部材種類指定
                /// </summary>
                public enm.CompType CompType_BuzaiKind = enm.CompType.Undefined;

                /// <summary>
                /// 部材種類
                /// </summary>
                public List<zPMxCom.enm.BuzaiKind> BuzaiKind = new List<zPMxCom.enm.BuzaiKind>();

                /// <summary>
                /// サイズ1指定
                /// </summary>
                public enm.CompType CompType_Size1 = enm.CompType.Undefined;

                /// <summary>
                /// サイズ1下限
                /// </summary>
                public double Size1Min;

                /// <summary>
                /// サイズ1上限
                /// </summary>
                public double Size1Max;

                /// <summary>
                /// サイズ2指定
                /// </summary>
                public enm.CompType CompType_Size2 = enm.CompType.Undefined;

                /// <summary>
                /// サイズ2下限
                /// </summary>
                public double Size2Min;

                /// <summary>
                /// サイズ2上限
                /// </summary>
                public double Size2Max;

                /// <summary>
                /// サイズ3指定
                /// </summary>
                public enm.CompType CompType_Size3 = enm.CompType.Undefined;

                /// <summary>
                /// サイズ3下限
                /// </summary>
                public double Size3Min;

                /// <summary>
                /// サイズ3上限
                /// </summary>
                public double Size3Max;

                /// <summary>
                /// サイズ4指定
                /// </summary>
                public enm.CompType CompType_Size4 = enm.CompType.Undefined;

                /// <summary>
                /// サイズ4下限
                /// </summary>
                public double Size4Min;

                /// <summary>
                /// サイズ4上限
                /// </summary>
                public double Size4Max;

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolWorkSection   - in セクションデータ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolWorkSection">セクションデータ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.WorkSection> vcolWorkSection)
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
                            objWriter.WriteStartElement("WorkSectionData");
                            {
                                foreach (zPMxMst.typ.WorkSection objWorkSection in vcolWorkSection)
                                {
                                    objWriter.WriteStartElement("WorkSection");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objWorkSection.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objWorkSection.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("FactoryID");
                                        {
                                            objWriter.WriteString(objWorkSection.FactoryID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objWorkSection.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objWorkSection.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Place");
                                        {
                                            objWriter.WriteString(objWorkSection.Place.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("OutsourcingReturn");
                                        {
                                            objWriter.WriteString(objWorkSection.OutsourcingReturn.ToString().ToLower());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("OutsourcingTerm");
                                        {
                                            objWriter.WriteString(objWorkSection.OutsourcingTerm.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Ability");
                                        {
                                            objWriter.WriteString(objWorkSection.Ability.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Amount");
                                        {
                                            objWriter.WriteString(objWorkSection.Amount.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Attrib");
                                        {
                                            objWriter.WriteString(objWorkSection.Attrib.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Haunch");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Haunch.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Haunch");
                                        {
                                            objWriter.WriteString(objWorkSection.Haunch.ToString().ToLower());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_PlatingType");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_PlatingType.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("PlatingType");
                                        {
                                            objWriter.WriteString(objWorkSection.PlatingType.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_WeldScallopKind");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_WeldScallopKind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WeldScallopKind");
                                        {
                                            objWriter.WriteString(objWorkSection.WeldScallopKind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_WeldTip");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_WeldTip.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WeldTip");
                                        {
                                            objWriter.WriteString(objWorkSection.WeldTip.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Std");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Std.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("StdIDData");
                                        {
                                            foreach (int intStdID in objWorkSection.StdID)
                                            {
                                                objWriter.WriteStartElement("StdID");
                                                {
                                                    objWriter.WriteString(intStdID.ToString());
                                                }
                                                objWriter.WriteEndElement();
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Shape");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Shape.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ShapeIDData");
                                        {
                                            foreach (int intShapeID in objWorkSection.ShapeID)
                                            {
                                                objWriter.WriteStartElement("ShapeID");
                                                {
                                                    objWriter.WriteString(intShapeID.ToString());
                                                }
                                                objWriter.WriteEndElement();
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Kind");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Kind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("KindIDData");
                                        {
                                            foreach (int intKindID in objWorkSection.KindID)
                                            {
                                                objWriter.WriteStartElement("KindID");
                                                {
                                                    objWriter.WriteString(intKindID.ToString());
                                                }
                                                objWriter.WriteEndElement();
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_BuzaiKind");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_BuzaiKind.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("BuzaiKindData");
                                        {
                                            foreach (zPMxCom.enm.BuzaiKind enmBuzaiKind in objWorkSection.BuzaiKind)
                                            {
                                                objWriter.WriteStartElement("BuzaiKind");
                                                {
                                                    objWriter.WriteString(enmBuzaiKind.ToString());
                                                }
                                                objWriter.WriteEndElement();
                                            }
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Size1");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Size1.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size1Min");
                                        {
                                            objWriter.WriteString(objWorkSection.Size1Min.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size1Max");
                                        {
                                            objWriter.WriteString(objWorkSection.Size1Max.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Size2");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Size2.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size2Min");
                                        {
                                            objWriter.WriteString(objWorkSection.Size2Min.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size2Max");
                                        {
                                            objWriter.WriteString(objWorkSection.Size2Max.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Size3");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Size3.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size3Min");
                                        {
                                            objWriter.WriteString(objWorkSection.Size3Min.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size3Max");
                                        {
                                            objWriter.WriteString(objWorkSection.Size3Max.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("CompType_Size4");
                                        {
                                            objWriter.WriteString(objWorkSection.CompType_Size4.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size4Min");
                                        {
                                            objWriter.WriteString(objWorkSection.Size4Min.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Size4Max");
                                        {
                                            objWriter.WriteString(objWorkSection.Size4Max.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolWorkSection   - out セクションデータ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolWorkSection">セクションデータ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.WorkSection> rcolWorkSection)
                {
                    rcolWorkSection = new List<WorkSection>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.WorkSection objWorkSection = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "WorkSection":
                                        {
                                            objWorkSection = new WorkSection();
                                            rcolWorkSection.Add(objWorkSection);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objWorkSection.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objWorkSection.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "FactoryID":
                                        {
                                            objWorkSection.FactoryID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objWorkSection.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objWorkSection.Name = objReader.ReadElementContentAsString();
                                        }
                                        break;

                                    case "Place":
                                        {
                                            objWorkSection.Place = zPMxCom.Conv_StringToEnum<zPMxMst.enm.WorkPlace>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "OutsourcingReturn":
                                        {
                                            objWorkSection.OutsourcingReturn = objReader.ReadElementContentAsBoolean();
                                        }
                                        break;

                                    case "OutsourcingTerm":
                                        {
                                            objWorkSection.OutsourcingTerm = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Ability":
                                        {
                                            objWorkSection.Ability = zPMxCom.Conv_StringToEnum<zPMxMst.enm.Ability>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Amount":
                                        {
                                            objWorkSection.Amount = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Attrib":
                                        {
                                            objWorkSection.Attrib = zPMxCom.Conv_StringToEnum<zPMxMst.enm.Attrib>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "CompType_Haunch":
                                        {
                                            objWorkSection.CompType_Haunch = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Haunch":
                                        {
                                            objWorkSection.Haunch = objReader.ReadElementContentAsBoolean();
                                        }
                                        break;

                                    case "CompType_PlatingType":
                                        {
                                            objWorkSection.CompType_PlatingType = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "PlatingType":
                                        {
                                            objWorkSection.PlatingType = zPMxCom.Conv_StringToEnum<zPMxMst.enm.PlatingType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "CompType_WeldScallopKind":
                                        {
                                            objWorkSection.CompType_WeldScallopKind = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "WeldScallopKind":
                                        {
                                            objWorkSection.WeldScallopKind = zPMxCom.Conv_StringToEnum<zPMxCom.enm.WeldScallopKind>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "CompType_WeldTip":
                                        {
                                            objWorkSection.CompType_WeldTip = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "WeldTip":
                                        {
                                            objWorkSection.WeldTip = zPMxCom.Conv_StringToEnum<zPMxMst.enm.WeldTip>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "CompType_Std":
                                        {
                                            objWorkSection.CompType_Std = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "StdID":
                                        {
                                            objWorkSection.StdID.Add(objReader.ReadElementContentAsInt());
                                        }
                                        break;

                                    case "CompType_Shape":
                                        {
                                            objWorkSection.CompType_Shape = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "ShapeID":
                                        {
                                            objWorkSection.ShapeID.Add(objReader.ReadElementContentAsInt());
                                        }
                                        break;

                                    case "CompType_Kind":
                                        {
                                            objWorkSection.CompType_Kind = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "KindID":
                                        {
                                            objWorkSection.KindID.Add(objReader.ReadElementContentAsInt());
                                        }
                                        break;

                                    case "CompType_BuzaiKind":
                                        {
                                            objWorkSection.CompType_BuzaiKind = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "BuzaiKind":
                                        {
                                            objWorkSection.BuzaiKind.Add(zPMxCom.Conv_StringToEnum<zPMxCom.enm.BuzaiKind>(objReader.ReadElementContentAsString()));
                                        }
                                        break;

                                    case "CompType_Size1":
                                        {
                                            objWorkSection.CompType_Size1 = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Size1Min":
                                        {
                                            objWorkSection.Size1Min = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Size1Max":
                                        {
                                            objWorkSection.Size1Max = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "CompType_Size2":
                                        {
                                            objWorkSection.CompType_Size2 = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Size2Min":
                                        {
                                            objWorkSection.Size2Min = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Size2Max":
                                        {
                                            objWorkSection.Size2Max = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "CompType_Size3":
                                        {
                                            objWorkSection.CompType_Size3 = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Size3Min":
                                        {
                                            objWorkSection.Size3Min = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Size3Max":
                                        {
                                            objWorkSection.Size3Max = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "CompType_Size4":
                                        {
                                            objWorkSection.CompType_Size4 = zPMxCom.Conv_StringToEnum<zPMxMst.enm.CompType>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Size4Min":
                                        {
                                            objWorkSection.Size4Min = objReader.ReadElementContentAsDouble();
                                        }
                                        break;

                                    case "Size4Max":
                                        {
                                            objWorkSection.Size4Max = objReader.ReadElementContentAsDouble();
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
            // Title   : 製作工程
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 製作工程
            /// </summary>
            public class WorkProcess
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
                public WorkProcess()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public WorkProcess(WorkProcess vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.Flag = vobjOther.Flag;
                    this.Name = vobjOther.Name;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                ///// <summary>
                ///// 構成セクション
                ///// </summary>
                //public List<typ.CompSec> CompSecData = new List<CompSec>();

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolWorkProcess   - in 製作工程データ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolWorkProcess">製作工程データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.WorkProcess> vcolWorkProcess)
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
                            objWriter.WriteStartElement("WorkProcessData");
                            {
                                foreach (zPMxMst.typ.WorkProcess objWorkProcess in vcolWorkProcess)
                                {
                                    objWriter.WriteStartElement("WorkProcess");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objWorkProcess.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objWorkProcess.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objWorkProcess.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objWorkProcess.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolWorkProcess   - out 製作工程データ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolWorkProcess">製作工程データ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.WorkProcess> rcolWorkProcess)
                {
                    rcolWorkProcess = new List<WorkProcess>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.WorkProcess objWorkProcess = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "WorkProcess":
                                        {
                                            objWorkProcess = new WorkProcess();
                                            rcolWorkProcess.Add(objWorkProcess);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objWorkProcess.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objWorkProcess.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objWorkProcess.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objWorkProcess.Name = objReader.ReadElementContentAsString();
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
            // Title   : 構成セクション
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 構成セクション
            /// </summary>
            public class CompSec
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
                public CompSec()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public CompSec(CompSec vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.WorkProcessID = vobjOther.WorkProcessID;
                    this.ID = vobjOther.ID;
                    this.Flag = vobjOther.Flag;
                    this.WorkOrder = vobjOther.WorkOrder;
                    this.WorkSecID = vobjOther.WorkSecID;
                    this.DepartmentID1 = vobjOther.DepartmentID1;
                    this.DepartmentID2 = vobjOther.DepartmentID2;
                    this.DepartmentID3 = vobjOther.DepartmentID3;
                    this.OutsourcingID = vobjOther.OutsourcingID;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// 製作工程ID
                /// </summary>
                public int WorkProcessID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 実行順
                /// </summary>
                public int WorkOrder;

                /// <summary>
                /// セクションID
                /// </summary>
                public int WorkSecID;

                /// <summary>
                /// 班ID1
                /// </summary>
                public int DepartmentID1;

                /// <summary>
                /// 班ID2
                /// </summary>
                public int DepartmentID2;

                /// <summary>
                /// 班ID3
                /// </summary>
                public int DepartmentID3;

                /// <summary>
                /// 外注先ID
                /// </summary>
                public int OutsourcingID;

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolCompSec       - in 構成セクションデータ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolCompSec">構成セクションデータ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.CompSec> vcolCompSec)
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
                            objWriter.WriteStartElement("CompSecData");
                            {
                                foreach (zPMxMst.typ.CompSec objCompSec in vcolCompSec)
                                {
                                    objWriter.WriteStartElement("CompSec");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objCompSec.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WorkProcessID");
                                        {
                                            objWriter.WriteString(objCompSec.WorkProcessID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objCompSec.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objCompSec.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WorkOrder");
                                        {
                                            objWriter.WriteString(objCompSec.WorkOrder.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("WorkSecID");
                                        {
                                            objWriter.WriteString(objCompSec.WorkSecID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DepartmentID1");
                                        {
                                            objWriter.WriteString(objCompSec.DepartmentID1.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DepartmentID2");
                                        {
                                            objWriter.WriteString(objCompSec.DepartmentID2.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("DepartmentID3");
                                        {
                                            objWriter.WriteString(objCompSec.DepartmentID3.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("OutsourcingID");
                                        {
                                            objWriter.WriteString(objCompSec.OutsourcingID.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolCompSec       - out 構成セクションデータ
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolCompSec">構成セクションデータ</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.CompSec> rcolCompSec)
                {
                    rcolCompSec = new List<CompSec>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.CompSec objCompSec = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "CompSec":
                                        {
                                            objCompSec = new CompSec();
                                            rcolCompSec.Add(objCompSec);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objCompSec.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "WorkProcessID":
                                        {
                                            objCompSec.WorkProcessID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objCompSec.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objCompSec.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "WorkOrder":
                                        {
                                            objCompSec.WorkOrder = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "WorkSecID":
                                        {
                                            objCompSec.WorkSecID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DepartmentID1":
                                        {
                                            objCompSec.DepartmentID1 = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DepartmentID2":
                                        {
                                            objCompSec.DepartmentID2 = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "DepartmentID3":
                                        {
                                            objCompSec.DepartmentID3 = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "OutsourcingID":
                                        {
                                            objCompSec.OutsourcingID = objReader.ReadElementContentAsInt();
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
            // Title   : 外注先
            // Date    : 2020/ 4/17
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 外注先
            /// </summary>
            public class Outsourcing
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
                public Outsourcing()
                { }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コピーコンストラクタ
                //
                // 引き数　　: vobjOther     - in コピー元
                //
                // 備考　　　: 2020/ 5/12 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コピーコンストラクタ
                /// </summary>
                /// <param name="vobjOther">コピー元</param>
                public Outsourcing(Outsourcing vobjOther)
                {
                    this.FabID = vobjOther.FabID;
                    this.ID = vobjOther.ID;
                    this.Flag = vobjOther.Flag;
                    this.Name = vobjOther.Name;
                }

                /// <summary>
                /// ファブID
                /// </summary>
                public int FabID;

                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 状態
                /// </summary>
                public zPMxCom.enm.DataFlag Flag = zPMxCom.enm.DataFlag.Added;

                /// <summary>
                /// 名称
                /// </summary>
                public string Name = "";

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル保存
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: vcolOutsourcing   - in 外注先データ
                //
                // 備考　　　: 2020/ 5/25 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル保存
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="vcolOutsourcing">外注先データ</param>
                public static void Write(string vstrFilePath,
                                         List<zPMxMst.typ.Outsourcing> vcolOutsourcing)
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
                            objWriter.WriteStartElement("OutsourcingData");
                            {
                                foreach (zPMxMst.typ.Outsourcing objOutsourcing in vcolOutsourcing)
                                {
                                    objWriter.WriteStartElement("Outsourcing");
                                    {
                                        objWriter.WriteStartElement("FabID");
                                        {
                                            objWriter.WriteString(objOutsourcing.FabID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("ID");
                                        {
                                            objWriter.WriteString(objOutsourcing.ID.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Flag");
                                        {
                                            objWriter.WriteString(objOutsourcing.Flag.ToString());
                                        }
                                        objWriter.WriteEndElement();

                                        objWriter.WriteStartElement("Name");
                                        {
                                            objWriter.WriteString(objOutsourcing.Name.ToString());
                                        }
                                        objWriter.WriteEndElement();
                                    }
                                    objWriter.WriteEndElement();
                                }
                            }
                            objWriter.WriteEndElement();
                        }
                        objWriter.WriteEndElement();

                        objWriter.Flush();
                    }
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: XMLファイル読み込み
                //
                // 引き数　　: vstrFilePath      - in ファイルパス
                // 　　　　　: rcolOutsourcing   - out 外注先
                //
                // 返り値　　: 真＝OK、偽＝NG
                //
                // 備考　　　: 2020/ 5/26 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// XMLファイル読み込み
                /// </summary>
                /// <param name="vstrFilePath">ファイルパス</param>
                /// <param name="rcolOutsourcing">外注先</param>
                /// <returns>真＝OK、偽＝NG</returns>
                public static bool Read(string vstrFilePath,
                                        out List<zPMxMst.typ.Outsourcing> rcolOutsourcing)
                {
                    rcolOutsourcing = new List<Outsourcing>();

                    if (File.Exists(vstrFilePath) == false)
                    {
                        return false;
                    }

                    zPMxMst.typ.Outsourcing objOutsourcing = null;

                    using (var objReader = XmlReader.Create(vstrFilePath))
                    {
                        while (!(objReader.EOF))
                        {
                            if (objReader.NodeType == XmlNodeType.Element)
                            {
                                switch (objReader.LocalName)
                                {
                                    case "Outsourcing":
                                        {
                                            objOutsourcing = new Outsourcing();
                                            rcolOutsourcing.Add(objOutsourcing);

                                            objReader.Read();
                                        }
                                        break;

                                    case "FabID":
                                        {
                                            objOutsourcing.FabID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "ID":
                                        {
                                            objOutsourcing.ID = objReader.ReadElementContentAsInt();
                                        }
                                        break;

                                    case "Flag":
                                        {
                                            objOutsourcing.Flag = zPMxCom.Conv_StringToEnum<zPMxCom.enm.DataFlag>(objReader.ReadElementContentAsString());
                                        }
                                        break;

                                    case "Name":
                                        {
                                            objOutsourcing.Name = objReader.ReadElementContentAsString();
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
        }//End Class
    }
}
