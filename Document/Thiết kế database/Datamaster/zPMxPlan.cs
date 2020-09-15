using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMx
{
    //-------------------------------------------------------------------------
    // Title   : 工程計画データ
    // Date    : 2020/ 4/24
    // Author  : 金子　淳哉
    // History :
    //-------------------------------------------------------------------------
    /// <summary>
    /// 工程計画データ
    /// </summary>
    public class zPMxPlan
    {
        //---------------------------------------------------------------------
        // Title   : 列挙型 格納クラス
        // Date    : 2020/ 4/30
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 列挙型 格納クラス
        /// </summary>
        public class enm
        {
            //-----------------------------------------------------------------
            // Title   : 工程計画対象種類
            // History : 2020/ 4/30 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 工程計画対象種類
            /// </summary>
            public enum TargetKind
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
                /// 仕口
                /// </summary>
                Shiguchi = 2,

                /// <summary>
                /// 製品
                /// </summary>
                Seihin = 3,

                /// <summary>
                /// 型板
                /// </summary>
                Kataita = 4,

                /// <summary>
                /// 部品
                /// </summary>
                Buhin = 5,

                /// <summary>
                /// セクション
                /// </summary>
                Section = 6,

                /// <summary>
                /// 製作グループ
                /// </summary>
                WorkGroup = 7,
            }

            //-------------------------------------------------------------------------
            // Title   : イベント種類
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// イベント種類
            /// </summary>
            public enum EventType
            {
                /// <summary>
                /// 通常
                /// </summary>
                Normal = 0,

                /// <summary>
                /// 完成予定日
                /// </summary>
                Completion = 1,

                /// <summary>
                /// 材料発注日
                /// </summary>
                OrderZairyo = 2,

                /// <summary>
                /// 材料納入日
                /// </summary>
                DeliveryZairyo = 3,

                /// <summary>
                /// 発送日
                /// </summary>
                Shipping = 4,
            }

            //-----------------------------------------------------------------
            // Title   : イベントマーク
            // History : 2020/ 4/30 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// イベントマーク
            /// </summary>
            public enum EventMark
            {
                /// <summary>
                /// なし
                /// </summary>
                None = 0,

                /// <summary>
                /// ○
                /// </summary>
                Circle = 1,

                /// <summary>
                /// ●
                /// </summary>
                CircleFill = 2,

                /// <summary>
                /// ◎
                /// </summary>
                CircleDouble = 3,

                /// <summary>
                /// △
                /// </summary>
                Triangle = 4,

                /// <summary>
                /// ▲
                /// </summary>
                TriangleFill = 5,

                /// <summary>
                /// □
                /// </summary>
                Rectangle = 6,

                /// <summary>
                /// ■
                /// </summary>
                RectangleFill = 7,

                /// <summary>
                /// ☆
                /// </summary>
                Star = 8,

                /// <summary>
                /// ★
                /// </summary>
                StarFill = 9,
            }

            //-----------------------------------------------------------------
            // Title   : 実績タイプ
            // History : 2020/ 4/30 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// 実績タイプ
            /// </summary>
            public enum ResultType
            {
                /// <summary>
                /// 未定義
                /// </summary>
                Undefined = 0,

                /// <summary>
                /// 開始
                /// </summary>
                Start = 1,

                /// <summary>
                /// 完了
                /// </summary>
                End = 2,
            }

            //-----------------------------------------------------------------
            // Title   : メモ枠種類
            // History : 2020/ 4/30 - 金子　淳哉
            //-----------------------------------------------------------------
            /// <summary>
            /// メモ枠種類
            /// </summary>
            public enum MemoFrame
            {
                /// <summary>
                /// なし
                /// </summary>
                None = 0,

                /// <summary>
                /// 四角
                /// </summary>
                Rectangle = 1,

                /// <summary>
                /// 角丸め
                /// </summary>
                CornerR = 2,
            }
        }//End Class

        //---------------------------------------------------------------------
        // Title   : 構造体 格納クラス
        // Date    : 2020/ 4/24
        // Author  : 金子　淳哉
        // History :
        //---------------------------------------------------------------------
        /// <summary>
        /// 構造体 格納クラス
        /// </summary>
        public class typ
        {
            //-------------------------------------------------------------------------
            // Title   : 生産管理システム用工程計画データ
            // Date    : 2020/ 5/ 1
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 生産管理システム用工程計画データ
            /// </summary>
            public class PMPlan
            {
                /// <summary>
                /// 工程計画
                /// </summary>
                public List<PPlan> Plan = new List<PPlan>();

                /// <summary>
                /// 工程実績
                /// </summary>
                public List<PResult> Result = new List<PResult>();

                /// <summary>
                /// イベント
                /// </summary>
                public List<PEvent> Event = new List<PEvent>();

                /// <summary>
                /// メモ
                /// </summary>
                public List<PMemo> Memo = new List<PMemo>();
            }

            //-------------------------------------------------------------------------
            // Title   : 工程計画
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 工程計画
            /// </summary>
            public class PPlan : zPMxCom.typ.BaseInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 対象種類
                /// </summary>
                public enm.TargetKind TargetKind = enm.TargetKind.Undefined;

                /// <summary>
                /// 対象データID
                /// </summary>
                public List<int> TargetID = new List<int>();

                /// <summary>
                /// 保留データID
                /// </summary>
                public List<int> PendingID = new List<int>();

                /// <summary>
                /// 名称
                /// </summary>
                /// <remarks>
                /// TargetKindがSectionの場合はセクション名称
                /// TargetKindがWorkGroupの場合は製作グループ名称
                /// それ以外は空文字
                /// </remarks>
                public string Name = "";

                /// <summary>
                /// 期間
                /// </summary>
                public typ.PTerm Term;

                /// <summary>
                /// 子データID
                /// </summary>
                /// <remarks>
                /// PPlan.ID
                /// </remarks>
                public List<int> Children = new List<int>();

                /// <summary>
                /// 製作工程ID
                /// </summary>
                public int WorkProcessID;

                /// <summary>
                /// 構成セクションID
                /// </summary>
                public int CompSecID;

                /// <summary>
                /// 外注変更
                /// </summary>
                public bool OutsourcingAlt = false;

                /// <summary>
                /// 外注戻り有り
                /// </summary>
                /// <remarks>
                /// OutsourcingAltがtrueの場合に有効
                /// </remarks>
                public bool OutsourcingReturn = false;

                /// <summary>
                /// 外注製作期間
                /// </summary>
                /// <remarks>
                /// 日数を指定
                /// OutsourcingAltがtrueの場合に有効
                /// </remarks>
                public int OutsourcingTerm = 1;

                /// <summary>
                /// 外注先ID
                /// </summary>
                /// <remarks>
                /// OutsourcingAltがtrueの場合に有効
                /// </remarks>
                public int OutsourcingID;

                /// <summary>
                /// 読み取り専用フラグ
                /// </summary>
                public bool ReadOnly = false;

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color = new zPMxCom.typ.Color(255, 255, 255);
            }

            //-------------------------------------------------------------------------
            // Title   : 工程実績
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 工程実績
            /// </summary>
            public class PResult : zPMxCom.typ.BaseInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// タイプ
                /// </summary>
                public enm.ResultType Type = enm.ResultType.Undefined;

                /// <summary>
                /// 対象種類
                /// </summary>
                public enm.TargetKind TargetKind = enm.TargetKind.Undefined;

                /// <summary>
                /// 対象データID
                /// </summary>
                public List<int> TargetID = new List<int>();

                /// <summary>
                /// 日時
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddhhmmss
                /// </remarks>
                public string DateTime = "";

                /// <summary>
                /// 製作工程ID
                /// </summary>
                public int WorkProcessID;

                /// <summary>
                /// 構成セクションID
                /// </summary>
                public int CompSecID;
            }

            //-------------------------------------------------------------------------
            // Title   : 期間
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// 期間
            /// </summary>
            public struct PTerm
            {
                /// <summary>
                /// 開始日時
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddhhmmss
                /// </remarks>
                public string Start;

                /// <summary>
                /// 終了日時
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddhhmmss
                /// </remarks>
                public string End;

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vusrDateTime  - in 日時
                //
                // 備考　　　: 2020/ 4/30 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vusrDateTime">日時</param>
                public PTerm(DateTime vusrDateTime)
                {
                    this.Start = vusrDateTime.ToString("yyyyMMddhhmmss");
                    this.End = vusrDateTime.ToString("yyyyMMddhhmmss");
                }

                //---------------------------------------------------------------------
                //
                // 機能　　　: コンストラクタ
                //
                // 引き数　　: vusrStartDate - in 開始日時
                // 　　　　　: vusrEndDate   - in 終了日時
                //
                // 備考　　　: 2020/ 4/30 - 金子　淳哉
                //
                //---------------------------------------------------------------------
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="vusrStartDate">開始日時</param>
                /// <param name="vusrEndDate">終了日時</param>
                public PTerm(DateTime vusrStartDate,
                             DateTime vusrEndDate)
                {
                    this.Start = vusrStartDate.ToString("yyyyMMddhhmmss");
                    this.End = vusrEndDate.ToString("yyyyMMddhhmmss");
                }
            }

            //-------------------------------------------------------------------------
            // Title   : イベント
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// イベント
            /// </summary>
            public class PEvent : zPMxCom.typ.BaseInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 種類
                /// </summary>
                public enm.EventType Type = enm.EventType.Normal;

                /// <summary>
                /// マーク
                /// </summary>
                public enm.EventMark Mark = enm.EventMark.None;

                /// <summary>
                /// 属性
                /// </summary>
                public zPMxMst.enm.Attrib Attrib = zPMxMst.enm.Attrib.Undefined;

                /// <summary>
                /// 日時
                /// </summary>
                /// <remarks>
                /// 数字14桁：yyyyMMddhhmmss
                /// </remarks>
                public string DateTime = "";

                /// <summary>
                /// 製作仕分けID
                /// </summary>
                /// <remarks>
                /// サイズ0の場合は全体的なイベントと見なす
                /// </remarks>
                public List<int> WorkClassID = new List<int>();

                /// <summary>
                /// 備考
                /// </summary>
                public string Remarks = "";

                /// <summary>
                /// 色
                /// </summary>
                public zPMxCom.typ.Color Color = new zPMxCom.typ.Color(0, 0, 0);

                /// <summary>
                /// 固定フラグ
                /// </summary>
                public bool Fixed = false;
            }

            //-------------------------------------------------------------------------
            // Title   : メモ
            // Date    : 2020/ 4/30
            // Author  : 金子　淳哉
            // History :
            //-------------------------------------------------------------------------
            /// <summary>
            /// メモ
            /// </summary>
            public class PMemo : zPMxCom.typ.BaseInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID;

                /// <summary>
                /// 枠
                /// </summary>
                public enm.MemoFrame Frame = enm.MemoFrame.None;

                /// <summary>
                /// 対象種類
                /// </summary>
                public enm.TargetKind TargetKind = enm.TargetKind.Undefined;

                /// <summary>
                /// 対象データID
                /// </summary>
                public int TargetID;

                /// <summary>
                /// 期間
                /// </summary>
                public typ.PTerm Term;

                /// <summary>
                /// 文字列
                /// </summary>
                public string Text = "";

                /// <summary>
                /// 前景色
                /// </summary>
                public zPMxCom.typ.Color ForeColor = new zPMxCom.typ.Color(0, 0, 0);

                /// <summary>
                /// 背景色
                /// </summary>
                public zPMxCom.typ.Color BackColor = new zPMxCom.typ.Color(0, 255, 255, 255);

                /// <summary>
                /// 幅
                /// </summary>
                /// <remarks>
                /// FrameがNone以外の場合に有効
                /// ※0は文字列に合せて自動調整
                /// </remarks>
                public int Width;

                /// <summary>
                /// 高さ
                /// </summary>
                /// <remarks>
                /// FrameがNone以外の場合に有効
                /// ※0は文字列に合せて自動調整
                /// </remarks>
                public int Height;
            }
        }//End Class
    }
}
