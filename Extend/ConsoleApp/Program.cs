
Console.WriteLine("Hello, NDC Security 2023!");

Directory.CreateDirectory("log");
Wasmtime.WasiConfiguration conf = new Wasmtime.WasiConfiguration()
    .WithStandardError("log/error.log")
    .WithStandardOutput("log/output.log")
    .WithArg("CalledFromConsole")
    .WithArgs(args); //passing args

var engineConfig = new Wasmtime.Config();
var engine = new Wasmtime.Engine(engineConfig);
var linker = new Wasmtime.Linker(engine);
linker.DefineWasi();
var store = new Wasmtime.Store(engine);
store.SetWasiConfiguration(conf);

string wasm = @"wasm/myrustmodule.wasm";
var module = Wasmtime.Module.FromFile(engine, wasm);
var inst = linker.Instantiate(store, module);
var main = inst.GetFunction("main");

if (main!=null)
    main.Invoke(0,0);