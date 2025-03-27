// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: dailywordle.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace WordleGameServer.Protos {

  /// <summary>Holder for reflection information generated from dailywordle.proto</summary>
  public static partial class DailywordleReflection {

    #region Descriptor
    /// <summary>File descriptor for dailywordle.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DailywordleReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFkYWlseXdvcmRsZS5wcm90bxIKd29yZGxlR2FtZSIdCgxHdWVzc1JlcXVl",
            "c3QSDQoFZ3Vlc3MYASABKAkirgEKDUd1ZXNzUmVzcG9uc2USDgoGcmVzdWx0",
            "GAEgASgJEhgKEGluY2x1ZGVkX2xldHRlcnMYAiADKAkSGAoQZXhjbHVkZWRf",
            "bGV0dGVycxgDIAMoCRIZChFhdmFpbGFibGVfbGV0dGVycxgEIAMoCRIRCgln",
            "YW1lX292ZXIYBSABKAgSEAoIZ2FtZV93b24YBiABKAgSGQoRZ3Vlc3Nlc19y",
            "ZW1haW5pbmcYByABKAUiDgoMU3RhdHNSZXF1ZXN0IlcKDVN0YXRzUmVzcG9u",
            "c2USFQoNdG90YWxfcGxheWVycxgBIAEoBRIWCg53aW5fcGVyY2VudGFnZRgC",
            "IAEoAhIXCg9hdmVyYWdlX2d1ZXNzZXMYAyABKAIyjwEKC0RhaWx5V29yZGxl",
            "Ej8KBFBsYXkSGC53b3JkbGVHYW1lLkd1ZXNzUmVxdWVzdBoZLndvcmRsZUdh",
            "bWUuR3Vlc3NSZXNwb25zZSgBMAESPwoIR2V0U3RhdHMSGC53b3JkbGVHYW1l",
            "LlN0YXRzUmVxdWVzdBoZLndvcmRsZUdhbWUuU3RhdHNSZXNwb25zZUIaqgIX",
            "V29yZGxlR2FtZVNlcnZlci5Qcm90b3NiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::WordleGameServer.Protos.GuessRequest), global::WordleGameServer.Protos.GuessRequest.Parser, new[]{ "Guess" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::WordleGameServer.Protos.GuessResponse), global::WordleGameServer.Protos.GuessResponse.Parser, new[]{ "Result", "IncludedLetters", "ExcludedLetters", "AvailableLetters", "GameOver", "GameWon", "GuessesRemaining" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::WordleGameServer.Protos.StatsRequest), global::WordleGameServer.Protos.StatsRequest.Parser, null, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::WordleGameServer.Protos.StatsResponse), global::WordleGameServer.Protos.StatsResponse.Parser, new[]{ "TotalPlayers", "WinPercentage", "AverageGuesses" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GuessRequest : pb::IMessage<GuessRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GuessRequest> _parser = new pb::MessageParser<GuessRequest>(() => new GuessRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GuessRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WordleGameServer.Protos.DailywordleReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GuessRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GuessRequest(GuessRequest other) : this() {
      guess_ = other.guess_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GuessRequest Clone() {
      return new GuessRequest(this);
    }

    /// <summary>Field number for the "guess" field.</summary>
    public const int GuessFieldNumber = 1;
    private string guess_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Guess {
      get { return guess_; }
      set {
        guess_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GuessRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GuessRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Guess != other.Guess) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Guess.Length != 0) hash ^= Guess.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Guess.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Guess);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Guess.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Guess);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Guess.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Guess);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GuessRequest other) {
      if (other == null) {
        return;
      }
      if (other.Guess.Length != 0) {
        Guess = other.Guess;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Guess = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Guess = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class GuessResponse : pb::IMessage<GuessResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GuessResponse> _parser = new pb::MessageParser<GuessResponse>(() => new GuessResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GuessResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WordleGameServer.Protos.DailywordleReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GuessResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GuessResponse(GuessResponse other) : this() {
      result_ = other.result_;
      includedLetters_ = other.includedLetters_.Clone();
      excludedLetters_ = other.excludedLetters_.Clone();
      availableLetters_ = other.availableLetters_.Clone();
      gameOver_ = other.gameOver_;
      gameWon_ = other.gameWon_;
      guessesRemaining_ = other.guessesRemaining_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GuessResponse Clone() {
      return new GuessResponse(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private string result_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Result {
      get { return result_; }
      set {
        result_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "included_letters" field.</summary>
    public const int IncludedLettersFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_includedLetters_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> includedLetters_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> IncludedLetters {
      get { return includedLetters_; }
    }

    /// <summary>Field number for the "excluded_letters" field.</summary>
    public const int ExcludedLettersFieldNumber = 3;
    private static readonly pb::FieldCodec<string> _repeated_excludedLetters_codec
        = pb::FieldCodec.ForString(26);
    private readonly pbc::RepeatedField<string> excludedLetters_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> ExcludedLetters {
      get { return excludedLetters_; }
    }

    /// <summary>Field number for the "available_letters" field.</summary>
    public const int AvailableLettersFieldNumber = 4;
    private static readonly pb::FieldCodec<string> _repeated_availableLetters_codec
        = pb::FieldCodec.ForString(34);
    private readonly pbc::RepeatedField<string> availableLetters_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> AvailableLetters {
      get { return availableLetters_; }
    }

    /// <summary>Field number for the "game_over" field.</summary>
    public const int GameOverFieldNumber = 5;
    private bool gameOver_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool GameOver {
      get { return gameOver_; }
      set {
        gameOver_ = value;
      }
    }

    /// <summary>Field number for the "game_won" field.</summary>
    public const int GameWonFieldNumber = 6;
    private bool gameWon_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool GameWon {
      get { return gameWon_; }
      set {
        gameWon_ = value;
      }
    }

    /// <summary>Field number for the "guesses_remaining" field.</summary>
    public const int GuessesRemainingFieldNumber = 7;
    private int guessesRemaining_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int GuessesRemaining {
      get { return guessesRemaining_; }
      set {
        guessesRemaining_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GuessResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GuessResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Result != other.Result) return false;
      if(!includedLetters_.Equals(other.includedLetters_)) return false;
      if(!excludedLetters_.Equals(other.excludedLetters_)) return false;
      if(!availableLetters_.Equals(other.availableLetters_)) return false;
      if (GameOver != other.GameOver) return false;
      if (GameWon != other.GameWon) return false;
      if (GuessesRemaining != other.GuessesRemaining) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Result.Length != 0) hash ^= Result.GetHashCode();
      hash ^= includedLetters_.GetHashCode();
      hash ^= excludedLetters_.GetHashCode();
      hash ^= availableLetters_.GetHashCode();
      if (GameOver != false) hash ^= GameOver.GetHashCode();
      if (GameWon != false) hash ^= GameWon.GetHashCode();
      if (GuessesRemaining != 0) hash ^= GuessesRemaining.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Result.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Result);
      }
      includedLetters_.WriteTo(output, _repeated_includedLetters_codec);
      excludedLetters_.WriteTo(output, _repeated_excludedLetters_codec);
      availableLetters_.WriteTo(output, _repeated_availableLetters_codec);
      if (GameOver != false) {
        output.WriteRawTag(40);
        output.WriteBool(GameOver);
      }
      if (GameWon != false) {
        output.WriteRawTag(48);
        output.WriteBool(GameWon);
      }
      if (GuessesRemaining != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(GuessesRemaining);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Result.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Result);
      }
      includedLetters_.WriteTo(ref output, _repeated_includedLetters_codec);
      excludedLetters_.WriteTo(ref output, _repeated_excludedLetters_codec);
      availableLetters_.WriteTo(ref output, _repeated_availableLetters_codec);
      if (GameOver != false) {
        output.WriteRawTag(40);
        output.WriteBool(GameOver);
      }
      if (GameWon != false) {
        output.WriteRawTag(48);
        output.WriteBool(GameWon);
      }
      if (GuessesRemaining != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(GuessesRemaining);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Result.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Result);
      }
      size += includedLetters_.CalculateSize(_repeated_includedLetters_codec);
      size += excludedLetters_.CalculateSize(_repeated_excludedLetters_codec);
      size += availableLetters_.CalculateSize(_repeated_availableLetters_codec);
      if (GameOver != false) {
        size += 1 + 1;
      }
      if (GameWon != false) {
        size += 1 + 1;
      }
      if (GuessesRemaining != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(GuessesRemaining);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GuessResponse other) {
      if (other == null) {
        return;
      }
      if (other.Result.Length != 0) {
        Result = other.Result;
      }
      includedLetters_.Add(other.includedLetters_);
      excludedLetters_.Add(other.excludedLetters_);
      availableLetters_.Add(other.availableLetters_);
      if (other.GameOver != false) {
        GameOver = other.GameOver;
      }
      if (other.GameWon != false) {
        GameWon = other.GameWon;
      }
      if (other.GuessesRemaining != 0) {
        GuessesRemaining = other.GuessesRemaining;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Result = input.ReadString();
            break;
          }
          case 18: {
            includedLetters_.AddEntriesFrom(input, _repeated_includedLetters_codec);
            break;
          }
          case 26: {
            excludedLetters_.AddEntriesFrom(input, _repeated_excludedLetters_codec);
            break;
          }
          case 34: {
            availableLetters_.AddEntriesFrom(input, _repeated_availableLetters_codec);
            break;
          }
          case 40: {
            GameOver = input.ReadBool();
            break;
          }
          case 48: {
            GameWon = input.ReadBool();
            break;
          }
          case 56: {
            GuessesRemaining = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Result = input.ReadString();
            break;
          }
          case 18: {
            includedLetters_.AddEntriesFrom(ref input, _repeated_includedLetters_codec);
            break;
          }
          case 26: {
            excludedLetters_.AddEntriesFrom(ref input, _repeated_excludedLetters_codec);
            break;
          }
          case 34: {
            availableLetters_.AddEntriesFrom(ref input, _repeated_availableLetters_codec);
            break;
          }
          case 40: {
            GameOver = input.ReadBool();
            break;
          }
          case 48: {
            GameWon = input.ReadBool();
            break;
          }
          case 56: {
            GuessesRemaining = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class StatsRequest : pb::IMessage<StatsRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<StatsRequest> _parser = new pb::MessageParser<StatsRequest>(() => new StatsRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<StatsRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WordleGameServer.Protos.DailywordleReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StatsRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StatsRequest(StatsRequest other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StatsRequest Clone() {
      return new StatsRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as StatsRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(StatsRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(StatsRequest other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
        }
      }
    }
    #endif

  }

  public sealed partial class StatsResponse : pb::IMessage<StatsResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<StatsResponse> _parser = new pb::MessageParser<StatsResponse>(() => new StatsResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<StatsResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WordleGameServer.Protos.DailywordleReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StatsResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StatsResponse(StatsResponse other) : this() {
      totalPlayers_ = other.totalPlayers_;
      winPercentage_ = other.winPercentage_;
      averageGuesses_ = other.averageGuesses_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StatsResponse Clone() {
      return new StatsResponse(this);
    }

    /// <summary>Field number for the "total_players" field.</summary>
    public const int TotalPlayersFieldNumber = 1;
    private int totalPlayers_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int TotalPlayers {
      get { return totalPlayers_; }
      set {
        totalPlayers_ = value;
      }
    }

    /// <summary>Field number for the "win_percentage" field.</summary>
    public const int WinPercentageFieldNumber = 2;
    private float winPercentage_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float WinPercentage {
      get { return winPercentage_; }
      set {
        winPercentage_ = value;
      }
    }

    /// <summary>Field number for the "average_guesses" field.</summary>
    public const int AverageGuessesFieldNumber = 3;
    private float averageGuesses_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float AverageGuesses {
      get { return averageGuesses_; }
      set {
        averageGuesses_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as StatsResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(StatsResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TotalPlayers != other.TotalPlayers) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(WinPercentage, other.WinPercentage)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(AverageGuesses, other.AverageGuesses)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (TotalPlayers != 0) hash ^= TotalPlayers.GetHashCode();
      if (WinPercentage != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(WinPercentage);
      if (AverageGuesses != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(AverageGuesses);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (TotalPlayers != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(TotalPlayers);
      }
      if (WinPercentage != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(WinPercentage);
      }
      if (AverageGuesses != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(AverageGuesses);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (TotalPlayers != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(TotalPlayers);
      }
      if (WinPercentage != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(WinPercentage);
      }
      if (AverageGuesses != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(AverageGuesses);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (TotalPlayers != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TotalPlayers);
      }
      if (WinPercentage != 0F) {
        size += 1 + 4;
      }
      if (AverageGuesses != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(StatsResponse other) {
      if (other == null) {
        return;
      }
      if (other.TotalPlayers != 0) {
        TotalPlayers = other.TotalPlayers;
      }
      if (other.WinPercentage != 0F) {
        WinPercentage = other.WinPercentage;
      }
      if (other.AverageGuesses != 0F) {
        AverageGuesses = other.AverageGuesses;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            TotalPlayers = input.ReadInt32();
            break;
          }
          case 21: {
            WinPercentage = input.ReadFloat();
            break;
          }
          case 29: {
            AverageGuesses = input.ReadFloat();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            TotalPlayers = input.ReadInt32();
            break;
          }
          case 21: {
            WinPercentage = input.ReadFloat();
            break;
          }
          case 29: {
            AverageGuesses = input.ReadFloat();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
