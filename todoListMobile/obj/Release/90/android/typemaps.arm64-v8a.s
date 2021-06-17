	.arch	armv8-a
	.file	"typemaps.arm64-v8a.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.word	3
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.word	240
/* java_type_count: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.arm64-v8a-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	3
	.global	map_modules
map_modules:
	/* module_uuid: a9762388-58b4-4450-af95-a04418bb4c61 */
	.byte	0x88, 0x23, 0x76, 0xa9, 0xb4, 0x58, 0x50, 0x44, 0xaf, 0x95, 0xa0, 0x44, 0x18, 0xbb, 0x4c, 0x61
	/* entry_count */
	.word	224
	/* duplicate_count */
	.word	41
	/* map */
	.xword	module0_managed_to_java
	/* duplicate_map */
	.xword	module0_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.xword	.L.map_aname.0
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: c4333cc3-a001-4750-b226-d1f262cfacd3 */
	.byte	0xc3, 0x3c, 0x33, 0xc4, 0x01, 0xa0, 0x50, 0x47, 0xb2, 0x26, 0xd1, 0xf2, 0x62, 0xcf, 0xac, 0xd3
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module1_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Essentials */
	.xword	.L.map_aname.1
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 723316fc-9625-4bb6-b105-23868a202656 */
	.byte	0xfc, 0x16, 0x33, 0x72, 0x25, 0x96, 0xb6, 0x4b, 0xb1, 0x05, 0x23, 0x86, 0x8a, 0x20, 0x26, 0x56
	/* entry_count */
	.word	15
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module2_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: ToDoListMobile */
	.xword	.L.map_aname.2
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	.size	map_modules, 216
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	2
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554754
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	50
	.zero	2

	/* #1 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554755
	/* java_name */
	.ascii	"android/app/AlertDialog"
	.zero	47
	.zero	2

	/* #2 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554756
	/* java_name */
	.ascii	"android/app/AlertDialog$Builder"
	.zero	39
	.zero	2

	/* #3 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554757
	/* java_name */
	.ascii	"android/app/Application"
	.zero	47
	.zero	2

	/* #4 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554759
	/* java_name */
	.ascii	"android/app/Application$ActivityLifecycleCallbacks"
	.zero	20
	.zero	2

	/* #5 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554760
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	52
	.zero	2

	/* #6 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554771
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	36
	.zero	2

	/* #7 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554773
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	35
	.zero	2

	/* #8 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554766
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	41
	.zero	2

	/* #9 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554764
	/* java_name */
	.ascii	"android/content/Context"
	.zero	47
	.zero	2

	/* #10 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554768
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	40
	.zero	2

	/* #11 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554779
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	39
	.zero	2

	/* #12 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554775
	/* java_name */
	.ascii	"android/content/DialogInterface$OnClickListener"
	.zero	23
	.zero	2

	/* #13 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554765
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	48
	.zero	2

	/* #14 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554785
	/* java_name */
	.ascii	"android/content/SharedPreferences"
	.zero	37
	.zero	2

	/* #15 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554781
	/* java_name */
	.ascii	"android/content/SharedPreferences$Editor"
	.zero	30
	.zero	2

	/* #16 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554783
	/* java_name */
	.ascii	"android/content/SharedPreferences$OnSharedPreferenceChangeListener"
	.zero	4
	.zero	2

	/* #17 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554787
	/* java_name */
	.ascii	"android/content/pm/PackageInfo"
	.zero	40
	.zero	2

	/* #18 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554789
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	37
	.zero	2

	/* #19 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554791
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	37
	.zero	2

	/* #20 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554577
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	38
	.zero	2

	/* #21 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554747
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	48
	.zero	2

	/* #22 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554748
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	49
	.zero	2

	/* #23 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554749
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	36
	.zero	2

	/* #24 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554751
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	27
	.zero	2

	/* #25 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554736
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	49
	.zero	2

	/* #26 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554737
	/* java_name */
	.ascii	"android/os/Build"
	.zero	54
	.zero	2

	/* #27 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554738
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	46
	.zero	2

	/* #28 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554740
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	53
	.zero	2

	/* #29 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554735
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	52
	.zero	2

	/* #30 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554743
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	53
	.zero	2

	/* #31 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554744
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	53
	.zero	2

	/* #32 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554742
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	49
	.zero	2

	/* #33 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554734
	/* java_name */
	.ascii	"android/preference/PreferenceManager"
	.zero	34
	.zero	2

	/* #34 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554837
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	36
	.zero	2

	/* #35 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554716
	/* java_name */
	.ascii	"android/text/Editable"
	.zero	49
	.zero	2

	/* #36 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554719
	/* java_name */
	.ascii	"android/text/GetChars"
	.zero	49
	.zero	2

	/* #37 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554722
	/* java_name */
	.ascii	"android/text/InputFilter"
	.zero	46
	.zero	2

	/* #38 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554724
	/* java_name */
	.ascii	"android/text/NoCopySpan"
	.zero	47
	.zero	2

	/* #39 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554726
	/* java_name */
	.ascii	"android/text/Spannable"
	.zero	48
	.zero	2

	/* #40 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554729
	/* java_name */
	.ascii	"android/text/Spanned"
	.zero	50
	.zero	2

	/* #41 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554732
	/* java_name */
	.ascii	"android/text/TextWatcher"
	.zero	46
	.zero	2

	/* #42 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554714
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	45
	.zero	2

	/* #43 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554712
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	43
	.zero	2

	/* #44 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554658
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	47
	.zero	2

	/* #45 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554660
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	38
	.zero	2

	/* #46 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554663
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	43
	.zero	2

	/* #47 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554671
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	46
	.zero	2

	/* #48 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554669
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	30
	.zero	2

	/* #49 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554665
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	38
	.zero	2

	/* #50 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554666
	/* java_name */
	.ascii	"android/view/Display"
	.zero	50
	.zero	2

	/* #51 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554680
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	47
	.zero	2

	/* #52 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554639
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	49
	.zero	2

	/* #53 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554641
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	40
	.zero	2

	/* #54 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554642
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	43
	.zero	2

	/* #55 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554644
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	35
	.zero	2

	/* #56 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554646
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	34
	.zero	2

	/* #57 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554673
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	53
	.zero	2

	/* #58 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554679
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	49
	.zero	2

	/* #59 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554675
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	26
	.zero	2

	/* #60 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554677
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	25
	.zero	2

	/* #61 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554647
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	46
	.zero	2

	/* #62 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554697
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	46
	.zero	2

	/* #63 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554683
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	50
	.zero	2

	/* #64 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554631
	/* java_name */
	.ascii	"android/view/View"
	.zero	53
	.zero	2

	/* #65 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554633
	/* java_name */
	.ascii	"android/view/View$OnClickListener"
	.zero	37
	.zero	2

	/* #66 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554636
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	25
	.zero	2

	/* #67 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554701
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	48
	.zero	2

	/* #68 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554702
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	35
	.zero	2

	/* #69 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554685
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	46
	.zero	2

	/* #70 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554687
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	47
	.zero	2

	/* #71 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554648
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	41
	.zero	2

	/* #72 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554650
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnGlobalLayoutListener"
	.zero	18
	.zero	2

	/* #73 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554652
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	23
	.zero	2

	/* #74 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554654
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnTouchModeChangeListener"
	.zero	15
	.zero	2

	/* #75 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554655
	/* java_name */
	.ascii	"android/view/Window"
	.zero	51
	.zero	2

	/* #76 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554657
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	42
	.zero	2

	/* #77 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554690
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	44
	.zero	2

	/* #78 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554688
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	31
	.zero	2

	/* #79 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554705
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	25
	.zero	2

	/* #80 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554711
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	19
	.zero	2

	/* #81 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554706
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	24
	.zero	2

	/* #82 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554579
	/* java_name */
	.ascii	"android/widget/AbsListView"
	.zero	44
	.zero	2

	/* #83 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554611
	/* java_name */
	.ascii	"android/widget/Adapter"
	.zero	48
	.zero	2

	/* #84 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554581
	/* java_name */
	.ascii	"android/widget/AdapterView"
	.zero	44
	.zero	2

	/* #85 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554583
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemLongClickListener"
	.zero	20
	.zero	2

	/* #86 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/BaseAdapter"
	.zero	44
	.zero	2

	/* #87 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554594
	/* java_name */
	.ascii	"android/widget/Button"
	.zero	49
	.zero	2

	/* #88 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554595
	/* java_name */
	.ascii	"android/widget/CheckBox"
	.zero	47
	.zero	2

	/* #89 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554613
	/* java_name */
	.ascii	"android/widget/Checkable"
	.zero	46
	.zero	2

	/* #90 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554596
	/* java_name */
	.ascii	"android/widget/CompoundButton"
	.zero	41
	.zero	2

	/* #91 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554598
	/* java_name */
	.ascii	"android/widget/CompoundButton$OnCheckedChangeListener"
	.zero	17
	.zero	2

	/* #92 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554604
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	47
	.zero	2

	/* #93 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554605
	/* java_name */
	.ascii	"android/widget/Filter"
	.zero	49
	.zero	2

	/* #94 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554607
	/* java_name */
	.ascii	"android/widget/Filter$FilterListener"
	.zero	34
	.zero	2

	/* #95 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554609
	/* java_name */
	.ascii	"android/widget/FrameLayout"
	.zero	44
	.zero	2

	/* #96 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554616
	/* java_name */
	.ascii	"android/widget/ImageButton"
	.zero	44
	.zero	2

	/* #97 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554617
	/* java_name */
	.ascii	"android/widget/ImageView"
	.zero	46
	.zero	2

	/* #98 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554615
	/* java_name */
	.ascii	"android/widget/ListAdapter"
	.zero	44
	.zero	2

	/* #99 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554620
	/* java_name */
	.ascii	"android/widget/ListView"
	.zero	47
	.zero	2

	/* #100 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554619
	/* java_name */
	.ascii	"android/widget/SpinnerAdapter"
	.zero	41
	.zero	2

	/* #101 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554590
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	47
	.zero	2

	/* #102 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554621
	/* java_name */
	.ascii	"android/widget/TimePicker"
	.zero	45
	.zero	2

	/* #103 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554622
	/* java_name */
	.ascii	"android/widget/Toast"
	.zero	50
	.zero	2

	/* #104 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554624
	/* java_name */
	.ascii	"android/widget/Toolbar"
	.zero	48
	.zero	2

	/* #105 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554626
	/* java_name */
	.ascii	"android/widget/Toolbar$OnMenuItemClickListener"
	.zero	24
	.zero	2

	/* #106 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"crc641afacd7dde7da634/AddTaskDialog"
	.zero	35
	.zero	2

	/* #107 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"crc641afacd7dde7da634/AllTaskAdapter"
	.zero	34
	.zero	2

	/* #108 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"crc641afacd7dde7da634/AllTasks"
	.zero	40
	.zero	2

	/* #109 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"crc641afacd7dde7da634/ButtonsLayout"
	.zero	35
	.zero	2

	/* #110 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"crc641afacd7dde7da634/CommonTasks"
	.zero	37
	.zero	2

	/* #111 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"crc641afacd7dde7da634/DailyTask"
	.zero	39
	.zero	2

	/* #112 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"crc641afacd7dde7da634/MainActivity"
	.zero	36
	.zero	2

	/* #113 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"crc641afacd7dde7da634/Register"
	.zero	40
	.zero	2

	/* #114 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"crc641afacd7dde7da634/Settings"
	.zero	40
	.zero	2

	/* #115 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"crc641afacd7dde7da634/TaskAdapter"
	.zero	37
	.zero	2

	/* #116 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"crc641afacd7dde7da634/TaskAdapter_Common"
	.zero	30
	.zero	2

	/* #117 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"crc641afacd7dde7da634/WeeklyTaskAdapter"
	.zero	31
	.zero	2

	/* #118 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"crc641afacd7dde7da634/WeeklyTasks"
	.zero	37
	.zero	2

	/* #119 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"crc641afacd7dde7da634/list_items"
	.zero	38
	.zero	2

	/* #120 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"crc641afacd7dde7da634/login"
	.zero	43
	.zero	2

	/* #121 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"crc64a0e0a82d0db9a07d/ActivityLifecycleContextListener"
	.zero	16
	.zero	2

	/* #122 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554980
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	53
	.zero	2

	/* #123 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554978
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	47
	.zero	2

	/* #124 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554982
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	53
	.zero	2

	/* #125 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554986
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	51
	.zero	2

	/* #126 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554983
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	51
	.zero	2

	/* #127 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554985
	/* java_name */
	.ascii	"java/io/InterruptedIOException"
	.zero	40
	.zero	2

	/* #128 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554989
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	50
	.zero	2

	/* #129 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554991
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	51
	.zero	2

	/* #130 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554988
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	50
	.zero	2

	/* #131 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554992
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	50
	.zero	2

	/* #132 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554993
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	56
	.zero	2

	/* #133 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554948
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	50
	.zero	2

	/* #134 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554924
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	53
	.zero	2

	/* #135 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554925
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	56
	.zero	2

	/* #136 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554949
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	48
	.zero	2

	/* #137 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554926
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	51
	.zero	2

	/* #138 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554927
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	55
	.zero	2

	/* #139 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554943
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	42
	.zero	2

	/* #140 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554928
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	38
	.zero	2

	/* #141 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554952
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	51
	.zero	2

	/* #142 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554954
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	50
	.zero	2

	/* #143 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554929
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	54
	.zero	2

	/* #144 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554944
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	56
	.zero	2

	/* #145 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554946
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	55
	.zero	2

	/* #146 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554930
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	51
	.zero	2

	/* #147 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554931
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	55
	.zero	2

	/* #148 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554955
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	36
	.zero	2

	/* #149 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554956
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	39
	.zero	2

	/* #150 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554957
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	35
	.zero	2

	/* #151 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554933
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	53
	.zero	2

	/* #152 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554960
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	48
	.zero	2

	/* #153 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554934
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	56
	.zero	2

	/* #154 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554961
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	40
	.zero	2

	/* #155 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554962
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	40
	.zero	2

	/* #156 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554963
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	54
	.zero	2

	/* #157 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554935
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	54
	.zero	2

	/* #158 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554965
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	32
	.zero	2

	/* #159 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554959
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	52
	.zero	2

	/* #160 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554936
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	44
	.zero	2

	/* #161 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554966
	/* java_name */
	.ascii	"java/lang/SecurityException"
	.zero	43
	.zero	2

	/* #162 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554937
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	55
	.zero	2

	/* #163 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554938
	/* java_name */
	.ascii	"java/lang/String"
	.zero	54
	.zero	2

	/* #164 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554940
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	54
	.zero	2

	/* #165 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554942
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	51
	.zero	2

	/* #166 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554967
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	31
	.zero	2

	/* #167 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554969
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	39
	.zero	2

	/* #168 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554971
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	36
	.zero	2

	/* #169 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554973
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	34
	.zero	2

	/* #170 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554975
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	48
	.zero	2

	/* #171 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554977
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	40
	.zero	2

	/* #172 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554861
	/* java_name */
	.ascii	"java/net/ConnectException"
	.zero	45
	.zero	2

	/* #173 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554863
	/* java_name */
	.ascii	"java/net/HttpURLConnection"
	.zero	44
	.zero	2

	/* #174 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554865
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	44
	.zero	2

	/* #175 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554866
	/* java_name */
	.ascii	"java/net/ProtocolException"
	.zero	44
	.zero	2

	/* #176 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554867
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	56
	.zero	2

	/* #177 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554868
	/* java_name */
	.ascii	"java/net/Proxy$Type"
	.zero	51
	.zero	2

	/* #178 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554869
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	48
	.zero	2

	/* #179 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554871
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	48
	.zero	2

	/* #180 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554873
	/* java_name */
	.ascii	"java/net/SocketException"
	.zero	46
	.zero	2

	/* #181 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554874
	/* java_name */
	.ascii	"java/net/SocketTimeoutException"
	.zero	39
	.zero	2

	/* #182 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554876
	/* java_name */
	.ascii	"java/net/URI"
	.zero	58
	.zero	2

	/* #183 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554877
	/* java_name */
	.ascii	"java/net/URL"
	.zero	58
	.zero	2

	/* #184 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554878
	/* java_name */
	.ascii	"java/net/URLConnection"
	.zero	48
	.zero	2

	/* #185 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554875
	/* java_name */
	.ascii	"java/net/UnknownServiceException"
	.zero	38
	.zero	2

	/* #186 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554900
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	55
	.zero	2

	/* #187 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554902
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	51
	.zero	2

	/* #188 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554907
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	41
	.zero	2

	/* #189 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554909
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	45
	.zero	2

	/* #190 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554904
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	41
	.zero	2

	/* #191 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554911
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	32
	.zero	2

	/* #192 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554913
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	32
	.zero	2

	/* #193 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554915
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	33
	.zero	2

	/* #194 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554917
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	31
	.zero	2

	/* #195 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554919
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	33
	.zero	2

	/* #196 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554921
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	33
	.zero	2

	/* #197 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554922
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	20
	.zero	2

	/* #198 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554887
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	48
	.zero	2

	/* #199 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554889
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	29
	.zero	2

	/* #200 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554891
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	28
	.zero	2

	/* #201 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554886
	/* java_name */
	.ascii	"java/security/Principal"
	.zero	47
	.zero	2

	/* #202 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554892
	/* java_name */
	.ascii	"java/security/SecureRandom"
	.zero	44
	.zero	2

	/* #203 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554893
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	40
	.zero	2

	/* #204 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554895
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	33
	.zero	2

	/* #205 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554898
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	36
	.zero	2

	/* #206 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554897
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	38
	.zero	2

	/* #207 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554829
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	51
	.zero	2

	/* #208 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554818
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	50
	.zero	2

	/* #209 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554881
	/* java_name */
	.ascii	"java/util/Enumeration"
	.zero	49
	.zero	2

	/* #210 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554820
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	53
	.zero	2

	/* #211 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554838
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	53
	.zero	2

	/* #212 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554883
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	52
	.zero	2

	/* #213 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554884
	/* java_name */
	.ascii	"java/util/Random"
	.zero	54
	.zero	2

	/* #214 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554549
	/* java_name */
	.ascii	"javax/net/SocketFactory"
	.zero	47
	.zero	2

	/* #215 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554554
	/* java_name */
	.ascii	"javax/net/ssl/HostnameVerifier"
	.zero	40
	.zero	2

	/* #216 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554551
	/* java_name */
	.ascii	"javax/net/ssl/HttpsURLConnection"
	.zero	38
	.zero	2

	/* #217 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554556
	/* java_name */
	.ascii	"javax/net/ssl/KeyManager"
	.zero	46
	.zero	2

	/* #218 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554565
	/* java_name */
	.ascii	"javax/net/ssl/KeyManagerFactory"
	.zero	39
	.zero	2

	/* #219 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554566
	/* java_name */
	.ascii	"javax/net/ssl/SSLContext"
	.zero	46
	.zero	2

	/* #220 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554558
	/* java_name */
	.ascii	"javax/net/ssl/SSLSession"
	.zero	46
	.zero	2

	/* #221 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554560
	/* java_name */
	.ascii	"javax/net/ssl/SSLSessionContext"
	.zero	39
	.zero	2

	/* #222 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554567
	/* java_name */
	.ascii	"javax/net/ssl/SSLSocketFactory"
	.zero	40
	.zero	2

	/* #223 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554562
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	44
	.zero	2

	/* #224 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554569
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	37
	.zero	2

	/* #225 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554564
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	40
	.zero	2

	/* #226 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554545
	/* java_name */
	.ascii	"javax/security/cert/Certificate"
	.zero	39
	.zero	2

	/* #227 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554547
	/* java_name */
	.ascii	"javax/security/cert/X509Certificate"
	.zero	35
	.zero	2

	/* #228 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33555016
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	46
	.zero	2

	/* #229 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554777
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnClickListenerImplementor"
	.zero	7
	.zero	2

	/* #230 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554814
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	31
	.zero	2

	/* #231 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	40
	.zero	2

	/* #232 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554835
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	39
	.zero	2

	/* #233 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554853
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	30
	.zero	2

	/* #234 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554634
	/* java_name */
	.ascii	"mono/android/view/View_OnClickListenerImplementor"
	.zero	21
	.zero	2

	/* #235 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554585
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemLongClickListenerImplementor"
	.zero	4
	.zero	2

	/* #236 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554600
	/* java_name */
	.ascii	"mono/android/widget/CompoundButton_OnCheckedChangeListenerImplementor"
	.zero	1
	.zero	2

	/* #237 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554628
	/* java_name */
	.ascii	"mono/android/widget/Toolbar_OnMenuItemClickListenerImplementor"
	.zero	8
	.zero	2

	/* #238 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554941
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	36
	.zero	2

	/* #239 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554544
	/* java_name */
	.ascii	"xamarin/android/net/OldAndroidSSLSocketFactory"
	.zero	24
	.zero	2

	.size	map_java, 19200
/* Java to managed map: END */


/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.word	72
/* java_name_width: END */
